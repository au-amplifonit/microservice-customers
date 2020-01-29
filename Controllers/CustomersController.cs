using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fox.Microservices.CommonUtils;
using Fox.Microservices.Customers.Helpers;
using Fox.Microservices.Customers.Models;
using Fox.Microservices.Customers.Models.Audiograms;
using Fox.Microservices.Customers.Models.Entities;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPITools.EntityMapper;
using WebAPITools.ErrorHandling;
using WebAPITools.Helpers;
using WebAPITools.Models;
using WebAPITools.Models.Configuration;
using LinqKit;
using System.Transactions;
using Microsoft.AspNetCore.Http;

namespace Fox.Microservices.Customers.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly IOptions<AppSettings> Settings;
		private readonly IFoxDataService FoxDataService;
		private readonly CustomersContext DBContext;
		private readonly IHttpContextAccessor HttpContextAccessor;

		public CustomersController(IOptions<AppSettings> ASettings, CustomersContext ADBContext, IFoxDataService foxDataService, IHttpContextAccessor httpContextAccessor)
		{
			this.Settings = ASettings;
			if (Settings != null)
				Settings.Value.Configure(httpContextAccessor);
			EntityMapper.Settings = Settings.Value;
			FoxDataService = foxDataService;
			DBContext = ADBContext;
			DBContext.Database.SetCommandTimeout(Settings.Value.CommandTimeout);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[NonAction]
		// GET api/values
		public ActionResult<IEnumerable<CustomerBase>> Get()
		{
			return null;
		}


		/// <summary>
		/// Given a Customer ID return full customer details + addresses
		/// </summary>
		/// <param name="id">The customer ID</param>
		/// <returns>Customer details</returns>
		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<CustomerExtended> Get(string id)
		{
			CustomerExtended Result = null;
			CU_B_ADDRESS_BOOK Item = DBContext.CU_B_ADDRESS_BOOK.FirstOrDefault(E => E.CUSTOMER_CODE == id);

			if (Item == null)
				throw new NotFoundException(string.Format("No customer found with key: '{0}'", id));

			Result = EntityMapper.Map<CustomerExtended, CU_B_ADDRESS_BOOK>(DBContext, Item, Item.CU_B_ADDRESS_BOOK_EXT_AUS);

			return Result;
		}

		/// <summary>
		/// Convert a lead to a customer
		/// </summary>
		/// <param name="xid">The customer ID</param>
		/// <returns>Customer's addresses</returns>
		[HttpGet("[action]/{xid}")]
		public ActionResult<CustomerExtended> ConvertFromLead(string xid)
		{
			CustomerExtended Result = null;
			CU_B_LEAD_EXT_AUS Item = DBContext.CU_B_LEAD_EXT_AUS.FirstOrDefault(E => E.XID == xid);
			if (Item == null)
				throw new NotFoundException(string.Format("No lead found with xid: '{0}'", xid));

			Result = EntityMapper.Map<CustomerExtended, CU_B_LEAD_EXT_AUS>(DBContext, Item);

			Result.CustomerTypeCode = "QL";
			Result.StatusCode = "00"; //Force status to Active to avoid FOX issues

			return Result;
		}

		// POST api/values
		[HttpPost]
		public ActionResult<CustomerExtended> Post([FromBody] Customer value, string XID, string campaignCode, string mediaTypeCode)
		{
			CheckCustomerAge(value?.Birthday);
			CU_B_ADDRESS_BOOK Item = EntityMapper.CreateEntity<CU_B_ADDRESS_BOOK>();
			CU_B_ADDRESS_BOOK_EXT_AUS ItemExt = EntityMapper.CreateEntity<CU_B_ADDRESS_BOOK_EXT_AUS>();
			CU_B_ACTIVITY activity = EntityMapper.CreateEntity<CU_B_ACTIVITY>();
			CU_B_ACTIVITY_EXT_AUS activityExt = EntityMapper.CreateEntity<CU_B_ACTIVITY_EXT_AUS>();

			EntityMapper.UpdateEntity(value, Item, ItemExt);

			CM_B_SHOP shop = DBContext.CM_B_SHOP.FirstOrDefault(E => E.SHOP_CODE == ItemExt.SHOP_CODE);

			//Add default values
			Item.CUSTOMER_TYPE_CODE = "QL";
			Item.COUNTRY_CODE = Settings.Value.CountryCode;
			//Item.GENDER_CODE = Item.GENDER_CODE ?? "U";
			Item.STATUS_CODE = "00"; //Force status to Active to avoid FOX issues
			ItemExt.CURRENT_FILE_LOCATION = "000"; //Head office
			ItemExt.CURRENT_LOCATION_TYPE_CODE = "00"; //Head office
			ItemExt.SHOP_CODE = "000"; //Head office
			Item.CUSTOMER_ID = XID;
			//
			Item.CUSTOMER_CODE = FoxDataService.GetNewCounter("CU_B_ADDRESS_BOOK", "CUSTOMER_CODE", ItemExt.SHOP_CODE, Item.USERINSERT).FORMATTEDVALUE;
			activityExt.CUSTOMER_CODE = activity.CUSTOMER_CODE = value.ID = ItemExt.CUSTOMER_CODE = Item.CUSTOMER_CODE;
			EntityMapper.InitializeEntityStandardFields(activity);
			EntityMapper.InitializeEntityStandardFields(activityExt);
			activity.ACTIVITY_TYPE_CODE = "RR";
			activity.ACTIVITY_DATE = DateTime.Today;
			activity.LAPTOP_CODE = activityExt.LAPTOP_CODE = activity.SHOP_CODE = activityExt.SHOP_CODE = ItemExt.SHOP_CODE;
			activity.LOCATION_CODE = ItemExt.SHOP_CODE;
			activity.LOCATION_TYPE_CODE = ItemExt.SHOP_CODE == "000" ? "03" : "01";
			activity.ACTIVITY_ID = activityExt.ACTIVITY_ID = FoxDataService.GetNewCounter("CU_B_ACTIVITY", "ACTIVITY_ID", ItemExt.SHOP_CODE, Item.USERINSERT).VALUE.GetValueOrDefault();
			EntityMapper.CheckEntityRowId(activity, activityExt, Guid.NewGuid());

			/* Disabled FK check
			//Check for valid campaign
			if (!string.IsNullOrWhiteSpace(campaignCode))
			{
				CM_S_CAMPAIGN campaign = DBContext.CM_S_CAMPAIGN.FirstOrDefault(E => E.CAMPAIGN_CODE == campaignCode);
				activity.CAMPAIGN_CODE = campaign?.CAMPAIGN_CODE;
			}
			//Check for valid mediatype
			if (!string.IsNullOrWhiteSpace(mediaTypeCode))
			{
				CM_S_MEDIATYPE mediaType = DBContext.CM_S_MEDIATYPE.FirstOrDefault(E => E.MEDIATYPE_CODE == mediaTypeCode);
				activity.MEDIATYPE_CODE = mediaType?.MEDIATYPE_CODE;
			}
			*/
			activity.CAMPAIGN_CODE = campaignCode;
			activity.MEDIATYPE_CODE = mediaTypeCode;

			DBContext.CU_B_ADDRESS_BOOK.Add(Item);
			DBContext.CU_B_ADDRESS_BOOK_EXT_AUS.Add(ItemExt);
			DBContext.CU_B_ACTIVITY.Add(activity);
			DBContext.CU_B_ACTIVITY_EXT_AUS.Add(activityExt);

			value.SaveData<CU_B_ADDRESS_BOOK>(DBContext, Item);

			if (value.Addresses != null)
			{
				int? AddressCounter = null;
				Address Addr = value.Addresses.FirstOrDefault(E => E.IsHomeAddress);
				if (Addr != null)
					CreateAddressEntity(Addr, ref AddressCounter, Item.CUSTOMER_CODE);

				Addr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsInvoiceDefault);
				if (Addr != null)
					CreateAddressEntity(Addr, ref AddressCounter, Item.CUSTOMER_CODE);

				Addr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsMailingDefault);
				if (Addr != null)
					CreateAddressEntity(Addr, ref AddressCounter, Item.CUSTOMER_CODE);

				Addr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsOtherContact);
				if (Addr != null)
					CreateAddressEntity(Addr, ref AddressCounter, Item.CUSTOMER_CODE);

				Addr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsHomeVisitDefault);
				if (Addr != null)
					CreateAddressEntity(Addr, ref AddressCounter, Item.CUSTOMER_CODE);
			}

			if (!string.IsNullOrWhiteSpace(XID))//Creating customer from lead
			{
				CU_B_LEAD_EXT_AUS Lead = DBContext.CU_B_LEAD_EXT_AUS.FirstOrDefault(E => E.XID == XID);
				if (Lead != null)
				{
					Lead.CUSTOMER_CODE = Item.CUSTOMER_CODE;
					Lead.STATUS_CODE = "30";
					EntityMapper.UpdateEntityStandardFields(Lead);
				}
			}

			DBContext.Database.GetDbConnection().Open();
			try
			{
				var Transaction = DBContext.Database.GetDbConnection().BeginTransaction();
				try
				{
					DBContext.Database.UseTransaction(Transaction);
					DBContext.SaveChanges();
					StringBuilder SQL = new StringBuilder("p_CU_B_CUSTOMER_MAPPING_getxidfrom_Customer_Code");
					/*
					SQL.Append("@COMPANY_CODE = {0} ");
					SQL.Append(", @DIVISION_CODE = {1}");
					SQL.Append(", @CUSTOMER_CODE = {2}");
					SQL.Append(", @DT_INSERT = {3}");
					SQL.Append(", @USERINSERT = {4}");
					SQL.Append(", @DT_UPDATE = {5}");
					SQL.Append(", @USERUPDATE = {6}");
					*/
					object[] parameters = new object[] { Settings.Value.CompanyCode, Settings.Value.CompanyCode, Item.CUSTOMER_CODE, Item.DT_INSERT, Item.USERINSERT, Item.DT_UPDATE, Item.USERUPDATE };
					var Connection = DBContext.Database.GetDbConnection();
					var Command = Connection.CreateCommand();
					Command.Transaction = Transaction;
					Command.CommandType = CommandType.StoredProcedure;
					Command.CommandText = SQL.ToString();
					Command.Parameters.Add(new SqlParameter("@COMPANY_CODE", Settings.Value.CompanyCode));
					Command.Parameters.Add(new SqlParameter("@DIVISION_CODE", Settings.Value.DivisionCode));
					Command.Parameters.Add(new SqlParameter("@CUSTOMER_CODE", Item.CUSTOMER_CODE));
					Command.Parameters.Add(new SqlParameter("@DT_INSERT", Item.DT_INSERT));
					Command.Parameters.Add(new SqlParameter("@USERINSERT", Item.USERINSERT));
					Command.Parameters.Add(new SqlParameter("@DT_UPDATE", Item.DT_UPDATE));
					Command.Parameters.Add(new SqlParameter("@USERUPDATE", Item.USERUPDATE));
					Command.ExecuteNonQuery();
					//DBContext.Database.ExecuteSqlCommand(SQL.ToString(), parameters: parameters);
					Transaction.Commit();
				}
				catch (Exception E)
				{
					Transaction.Rollback();
					throw E;
				}
				return Get(Item.CUSTOMER_CODE);
			}
			finally
			{
				DBContext.Database.GetDbConnection().Close();
			}
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public ActionResult<CustomerExtended> Put(string id, [FromBody] Customer value)
		{
			CheckCustomerAge(value?.Birthday);
			CU_B_ADDRESS_BOOK Item = DBContext.CU_B_ADDRESS_BOOK.SingleOrDefault(E => E.COMPANY_CODE == Settings.Value.CompanyCode && E.DIVISION_CODE == Settings.Value.DivisionCode && E.CUSTOMER_CODE == id);
			if (Item == null)
				throw new NotFoundException($"No customer found with id:{id}");

			if (string.IsNullOrWhiteSpace(value.ID))
				value.ID = id;

			EntityMapper.UpdateEntity(value, Item, Item.CU_B_ADDRESS_BOOK_EXT_AUS);

			value.SaveData<CU_B_ADDRESS_BOOK>(DBContext, Item);

			if (value.Addresses != null)
			{
				int? AddressCounter = null;
				CU_B_ADDRESS AddressEntity = null;
				Address HomeAddr = value.Addresses.FirstOrDefault(E => E.IsHomeAddress);
				Address InvoiceAddr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsInvoiceDefault);
				Address MailingAddr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsMailingDefault);
				Address OtherContactAddr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsOtherContact);
				Address HomeVisitAddr = value.Addresses.FirstOrDefault(E => !E.IsHomeAddress && E.IsHomeVisitDefault);

				if (HomeAddr != null)
				{
					HomeAddr.IsInvoiceDefault = (InvoiceAddr == null);
					HomeAddr.IsMailingDefault = (MailingAddr == null);
					HomeAddr.IsHomeVisitDefault = (HomeVisitAddr == null);
					if (HomeAddr.RowGuid != Guid.Empty)
						AddressEntity = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.ROWGUID == HomeAddr.RowGuid);

					if (AddressEntity == null)
						CreateAddressEntity(HomeAddr, ref AddressCounter, Item.CUSTOMER_CODE);
					else
					{
						EntityMapper.UpdateEntity(HomeAddr, AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						CheckAddressData(AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						AddressCounter = AddressEntity.ADDRESS_COUNTER + 1;
					}
				}

				if (InvoiceAddr != null)
				{
					AddressEntity = null;
					if (InvoiceAddr.RowGuid != Guid.Empty)
						AddressEntity = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.ROWGUID == InvoiceAddr.RowGuid);

					if (AddressEntity == null)
						CreateAddressEntity(InvoiceAddr, ref AddressCounter, Item.CUSTOMER_CODE);
					else
					{
						EntityMapper.UpdateEntity(InvoiceAddr, AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						CheckAddressData(AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						AddressCounter = AddressEntity.ADDRESS_COUNTER + 1;
					}
				}

				if (MailingAddr != null)
				{
					AddressEntity = null;
					if (MailingAddr.RowGuid != Guid.Empty)
						AddressEntity = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.ROWGUID == MailingAddr.RowGuid);

					if (AddressEntity == null)
						CreateAddressEntity(MailingAddr, ref AddressCounter, Item.CUSTOMER_CODE);
					else
					{
						EntityMapper.UpdateEntity(MailingAddr, AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						CheckAddressData(AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						AddressCounter = AddressEntity.ADDRESS_COUNTER + 1;
					}
				}

				if (OtherContactAddr != null)
				{
					AddressEntity = null;
					if (OtherContactAddr.RowGuid != Guid.Empty)
						AddressEntity = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.ROWGUID == OtherContactAddr.RowGuid);

					if (AddressEntity == null)
						CreateAddressEntity(OtherContactAddr, ref AddressCounter, Item.CUSTOMER_CODE);
					else
					{
						EntityMapper.UpdateEntity(OtherContactAddr, AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						AddressCounter = AddressEntity.ADDRESS_COUNTER + 1;
					}
				}

				if (HomeVisitAddr != null)
				{
					AddressEntity = null;
					if (HomeVisitAddr.RowGuid != Guid.Empty)
						AddressEntity = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.ROWGUID == HomeVisitAddr.RowGuid);

					if (AddressEntity == null)
						CreateAddressEntity(HomeVisitAddr, ref AddressCounter, Item.CUSTOMER_CODE);
					else
					{
						EntityMapper.UpdateEntity(HomeVisitAddr, AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						CheckAddressData(AddressEntity, AddressEntity.CU_B_ADDRESS_EXT_AUS);
						AddressCounter = AddressEntity.ADDRESS_COUNTER + 1;
					}
				}
			}

			DBContext.SaveChanges();

			return Get(id);
		}

		void CheckCustomerAge(DateTime? birthDate)
		{
			if (!birthDate.HasValue)
				throw new ArgumentNullException("Birtdate cannot be null");

			int Age = CustomerHelper.CalculatAge(birthDate.Value);
			if (Age < 26)
				throw new InvalidOperationException("Customers younger than 26 years old are not allowed");
		}

		/*
		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		*/


		/// <summary>
		/// Given a customer ID returns all customer's addresses
		/// </summary>
		/// <param name="id">The customer ID</param>
		/// <returns>Customer's addresses</returns>
		[HttpGet("[action]/{id}")]
		public ActionResult<IEnumerable<AddressExtended>> Addresses(string id)
		{
			List<AddressExtended> Result = new List<AddressExtended>();
			foreach (CU_B_ADDRESS Item in DBContext.CU_B_ADDRESS.Where(E => E.CUSTOMER_CODE == id).OrderBy(E => E.ADDRESS_COUNTER))
			{
				AddressExtended address = EntityMapper.Map<AddressExtended, CU_B_ADDRESS>(DBContext, Item, Item.CU_B_ADDRESS_EXT_AUS);
				Result.Add(address);
			}

			return Result;
		}

		// POST api/values
		[HttpPost("Address")]
		public void AddressPost([FromBody] Address value)
		{
			int? addressCounter = null;
			CreateAddressEntity(value, ref addressCounter);

			DBContext.SaveChanges();
		}

		private void CreateAddressEntity(Address value, ref int? addressCounter, string customerCode = null)
		{
			CU_B_ADDRESS Item = EntityMapper.CreateEntity<CU_B_ADDRESS>();
			CU_B_ADDRESS_EXT_AUS ItemExt = EntityMapper.CreateEntity<CU_B_ADDRESS_EXT_AUS>();

			Item.CUSTOMER_CODE = ItemExt.CUSTOMER_CODE = value.CustomerCode ?? customerCode;

			IQueryable<CU_B_ADDRESS> qryAddresses = DBContext.CU_B_ADDRESS.Where(E => E.CUSTOMER_CODE == Item.CUSTOMER_CODE);
			addressCounter = qryAddresses.Any() ? Math.Max(qryAddresses.Max(E => E.ADDRESS_COUNTER) + 1, addressCounter.GetValueOrDefault(1)) : addressCounter.GetValueOrDefault(1);

			Item.ADDRESS_COUNTER = ItemExt.ADDRESS_COUNTER = addressCounter.Value;
			addressCounter = addressCounter.Value + 1;
			Item.ROWGUID = ItemExt.ROWGUID = Guid.NewGuid();

			EntityMapper.UpdateEntity(value, Item, ItemExt);
			CheckAddressData(Item, ItemExt);

			DBContext.CU_B_ADDRESS.Add(Item);
			DBContext.CU_B_ADDRESS_EXT_AUS.Add(ItemExt);
		}

		[HttpGet("[action]")]
		public bool IsAddressCityValid(string stateCode, string city, string areaCode, string zipCode)
		{
			short? cityCounter = null;
			string errorMessage = null;

			if (string.IsNullOrWhiteSpace(city))
				throw new ArgumentNullException(nameof(city));

			return FoxDataService.CheckAddressCityData(stateCode, city, ref areaCode, ref zipCode, out cityCounter, out errorMessage);
		}

		[HttpPost("City")]
		public void CityPost([FromBody] Address address)
		{
			FoxDataService.InsertCity(address);
		}

		private void CheckAddressData(CU_B_ADDRESS Item, CU_B_ADDRESS_EXT_AUS ItemExt)
		{
			short? cityCounter;
			string errorMessage;
			string areaCode = Item.AREA_CODE;
			string zipCode = Item.ZIP_CODE;
			if (FoxDataService.CheckAddressCityData(ItemExt.STATE_CODE, Item.CITY_NAME, ref areaCode, ref zipCode, out cityCounter, out errorMessage))
			{ 
				Item.AREA_CODE = areaCode;
				Item.ZIP_CODE = zipCode;
				Item.CITY_COUNTER = cityCounter;
			}
			else
				throw new InvalidOperationException(errorMessage);

			if (ItemExt.STATE_CODE != null)
			{
				CM_S_STATE_EXT_AUS state = DBContext.CM_S_STATE_EXT_AUS.FirstOrDefault(E => E.STATE_CODE == ItemExt.STATE_CODE);
				if (state == null)
					throw new InvalidOperationException("State Code is not correct");
			}
		}


		/// <summary>
		/// Insert a new attachment
		/// </summary>
		/// <param name="value">Attachment data</param>
		[HttpPost("Attachment")]
		public void AttachmentPost([FromBody] Attachment value)
		{
			if (value == null)
				throw new ArgumentNullException($"Argument value cannot be null");

			long WEIGHT_MAX = 363520;
			string ATTACHMENT_WEIGHT_MAX = FoxDataService.GetGlobalParameterValue<string>("CM_B_ATTACHMENT_WEIGHT_MAX", "5120");
			if (!string.IsNullOrEmpty(ATTACHMENT_WEIGHT_MAX))
			{
				WEIGHT_MAX = Convert.ToInt64(ATTACHMENT_WEIGHT_MAX) * 1024;
				if (value.AttachmentData?.LongLength > WEIGHT_MAX)
					throw new InvalidOperationException($"Max attachment size is {WEIGHT_MAX}Kb");
			}

			CM_B_ATTACHMENT Item = EntityMapper.CreateEntity<CM_B_ATTACHMENT>();

			EntityMapper.UpdateEntity(value, Item);

			Item.REASON_ID = Item.ROWGUID;
			Item.ATTACHMENT_COUNTER = Convert.ToInt64(FoxDataService.GetNewCounter("CM_B_ATTACHMENT", "ATTACHMENT_COUNTER", value.ShopCode, Item.USERINSERT).FORMATTEDVALUE);

			value.SaveData<CM_B_ATTACHMENT>(DBContext, Item);

			//Update customer's privacy flags
			if (value.AttachmentTypeCode == "PCF")
			{
				CU_B_ADDRESS_BOOK customer = DBContext.CU_B_ADDRESS_BOOK.Where(E => E.CUSTOMER_CODE == Item.CUSTOMER_CODE).FirstOrDefault();
				customer.FLG_PRIVACYPERSDATA = "Y";
				customer.CU_B_ADDRESS_BOOK_EXT_AUS.FLG_TO_CALL = "Y";
				EntityMapper.UpdateEntityStandardFields(customer);
				EntityMapper.UpdateEntityStandardFields(customer.CU_B_ADDRESS_BOOK_EXT_AUS);
			}

			DBContext.CM_B_ATTACHMENT.Add(Item);
			DBContext.SaveChanges();
		}

		[HttpPut("Address/{rowId}")]
		public void AddressPut(Guid rowId, [FromBody] Address value)
		{
			CU_B_ADDRESS Item = DBContext.CU_B_ADDRESS.SingleOrDefault(E => E.ROWGUID == rowId);
			if (Item == null)
				throw new NotFoundException($"No address found with RowId:{rowId}");

			EntityMapper.UpdateEntity(value, Item, Item.CU_B_ADDRESS_EXT_AUS);
			EntityMapper.CheckEntityRowId(Item, Item.CU_B_ADDRESS_EXT_AUS, rowId);

			DBContext.SaveChanges();
		}

		/// <summary>
		/// Given a customer ID returns all customer's vouchers
		/// </summary>
		/// <param name="id">The customer ID</param>
		/// <returns>Customer's vouchers</returns>
		[HttpGet("[action]/{id}")]
		public ActionResult<IEnumerable<Voucher>> Vouchers(string id)
		{
			List<Voucher> Result = new List<Voucher>();
			foreach (CU_B_VOUCHER_EXT_AUS Item in DBContext.CU_B_VOUCHER_EXT_AUS.Where(E => E.CUSTOMER_CODE == id))
				Result.Add(new Voucher(Item));

			return Result;
		}

		/// <summary>
		/// Search for customers by <paramref name="Firstname"/>, <paramref name="Lastname"/> and <paramref name="Birthdate"/>
		/// At least one parameter is needed
		/// </summary>
		/// <param name="Firstname">Customer's firstname (start with search performed)</param>
		/// <param name="Lastname">Customer's lastname (start with search performed)</param>
		/// <param name="Birthdate">Customer's birthdate (exact match search performed)</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public ActionResult<IEnumerable<CustomerListItem>> ByFirstameLastnameBirthdate(string Firstname, string Lastname, DateTime? Birthdate)
		{
			if (string.IsNullOrWhiteSpace(Firstname) && string.IsNullOrWhiteSpace(Lastname) && !Birthdate.HasValue)
				throw new Exception("At least one parameter is needed to call this API");

			var predicate = PredicateBuilder.New<CU_B_ADDRESS_BOOK>(true);
			if (!string.IsNullOrWhiteSpace(Firstname))
				predicate = predicate.And(E => E.FIRSTNAME.StartsWith(Firstname));
			if (!string.IsNullOrWhiteSpace(Lastname))
				predicate = predicate.And(E => E.LASTNAME.StartsWith(Lastname));
			if (Birthdate.HasValue)
				predicate = predicate.And(E => E.BIRTHDATE == Birthdate.Value.Date);

			List<CustomerListItem> Result = new List<CustomerListItem>();
			foreach (CU_B_ADDRESS_BOOK Item in DBContext.CU_B_ADDRESS_BOOK.Where(predicate).Take(Settings.Value.MaxQueryResult))
			{
				CustomerListItem ResultItem = EntityMapper.Map<CustomerListItem, CU_B_ADDRESS_BOOK>(DBContext, Item, Item.CU_B_ADDRESS_BOOK_EXT_AUS);
				Result.Add(ResultItem);
			}

			return Result;
		}


		/// <summary>
		/// Search for customers 
		/// </summary>
		/// <param name="lastname">Customers' lastname (start with match)</param>
		/// <param name="customerCode">Customer's code (exact match)</param>
		/// <param name="voucherID">Customer's voucher ID (exact match)</param>
		/// <param name="phoneNumber">Customers' phone number (exact match)</param>
		/// <param name="birthdate">Customers' birthdate</param>
		/// <param name="pageSize">Specify how many items should be returnerd (pagination)</param>
		/// <param name="pageNumber">Specify what page should be returned (pagination, 0 based)</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public ActionResult<QueryResult<CustomerListItem>> Search(string lastname, string customerCode, string voucherID, string phoneNumber, DateTime? birthdate, string shopCode, int pageSize = 20, int pageNumber = 0, bool SortAscending = true)
		{
			if (string.IsNullOrWhiteSpace(lastname) && string.IsNullOrWhiteSpace(customerCode) && string.IsNullOrWhiteSpace(voucherID) && string.IsNullOrWhiteSpace(phoneNumber) && !birthdate.HasValue)
				throw new Exception("At least one parameter is needed to call this API");

			var predicate = PredicateBuilder.New<CU_B_ADDRESS_BOOK>(true);
			if (!string.IsNullOrWhiteSpace(lastname))
				predicate = predicate.And(E => E.LASTNAME.StartsWith(lastname));
			if (!string.IsNullOrWhiteSpace(customerCode))
				predicate = predicate.And(E => E.CUSTOMER_CODE == customerCode);
			if (!string.IsNullOrWhiteSpace(voucherID))
				predicate = predicate.And(E => E.CU_B_VOUCHER_EXT_AUS.Count(V => V.VOUCHER_ID == voucherID) > 0);
			if (!string.IsNullOrWhiteSpace(shopCode))
				predicate = predicate.And(E => E.CU_B_ADDRESS_BOOK_EXT_AUS.SHOP_CODE == shopCode);
			if (!string.IsNullOrWhiteSpace(phoneNumber))
			{
				predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE1 == phoneNumber));
				predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE2 == phoneNumber));
				predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE3 == phoneNumber));
				predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.MOBILE == phoneNumber));
			}
			if (birthdate.HasValue)
				predicate = predicate.And(E => E.BIRTHDATE == birthdate.Value.Date);

			IQueryable<CU_B_ADDRESS_BOOK> qryCustomers = DBContext.CU_B_ADDRESS_BOOK.Include(E => E.CU_B_ADDRESS).Include(E => E.CU_B_VOUCHER_EXT_AUS);

			int RecordCount = qryCustomers.Where(predicate).Count();

			List<CustomerListItem> Result = new List<CustomerListItem>();
			if (SortAscending)
				qryCustomers = qryCustomers.OrderBy(E => E.LASTNAME).OrderBy(E => E.FIRSTNAME);
			else
				qryCustomers = qryCustomers.OrderByDescending(E => E.LASTNAME).OrderByDescending(E => E.FIRSTNAME);

			foreach (CU_B_ADDRESS_BOOK Item in QueryHelper.GetPageItems<CU_B_ADDRESS_BOOK>(qryCustomers.Where(predicate), pageSize, pageNumber))
			{
				CustomerListItem ResultItem = EntityMapper.Map<CustomerListItem, CU_B_ADDRESS_BOOK>(DBContext, Item, Item.CU_B_ADDRESS_BOOK_EXT_AUS);
				Result.Add(ResultItem);
			}

			return new QueryResult<CustomerListItem>(pageSize, RecordCount, pageNumber, Result);
		}

		/// <summary>
		/// Search for customers and leads
		/// </summary>
		/// <param name="lastname">Customer's/Lead's lastname</param>
		/// <param name="customerCode">Customer's/Lead's code</param>
		/// <param name="voucherID">Customer's/Lead's voucher</param>
		/// <param name="phoneNumber">Customer's/Lead's phone number</param>
		/// <param name="birthdate">Customer's/Lead's birthday</param>
		/// <param name="shopCode">Customer's/Lead's shopcode</param>
		/// <param name="IsLead">Filter between customers (false), leads (true) and both(not set)</param>
		/// <param name="pageSize">Page size</param>
		/// <param name="pageNumber">Page number</param>
		/// <param name="SortAscending">Sorted by lastname, firstname ascending(true , default) or descending</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public ActionResult<QueryResult<CustomerLeadListItem>> SearchCustomersAndLeads(string lastname, string firstname, string customerCode, string xid, string voucherID, string phoneNumber, DateTime? birthdate, string shopCode, bool? IsLead, int pageSize = 20, int pageNumber = 0, bool SortAscending = true)
		{
			if (string.IsNullOrWhiteSpace(lastname) && string.IsNullOrWhiteSpace(xid) && string.IsNullOrWhiteSpace(customerCode)
				&& string.IsNullOrWhiteSpace(voucherID) && string.IsNullOrWhiteSpace(phoneNumber) && !birthdate.HasValue)
				throw new ArgumentException("At least one of the following parameters is needed to call this API: Lastname, CustomerCode, XID, VoucherID, PhoneNumber, Birthdate");

			StringBuilder customerWhereCondition = new StringBuilder();
			StringBuilder leadWhereCondition = new StringBuilder();

			//Default search conditions for leads
			QueryHelper.AddWhereCondition(leadWhereCondition, $"L.CUSTOMER_CODE IS NULL");

			if (!string.IsNullOrWhiteSpace(lastname))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, $"A.LASTNAME LIKE'{lastname}%'");
				QueryHelper.AddWhereCondition(leadWhereCondition, $"L.LASTNAME LIKE'{lastname}%'");
			}
			if (!string.IsNullOrWhiteSpace(firstname))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, $"A.FIRSTNAME LIKE'{firstname}%'");
				QueryHelper.AddWhereCondition(leadWhereCondition, $"L.FIRSTNAME LIKE'{firstname}%'");
			}

			//Search from UI 
			if (!string.IsNullOrWhiteSpace(customerCode))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, $"A.CUSTOMER_CODE ='{customerCode}'");
				QueryHelper.AddWhereCondition(leadWhereCondition, $"L.XID = '{customerCode}'");
				//IsLead = false;
			}
			if (!string.IsNullOrWhiteSpace(xid))
			{
				QueryHelper.AddWhereCondition(leadWhereCondition, $"L.XID = '{xid}'");
				IsLead = true;
			}
			if (!string.IsNullOrWhiteSpace(shopCode))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, $"AEXT.SHOP_CODE ='{shopCode}'");
				IsLead = false;
			}
			if (!string.IsNullOrWhiteSpace(voucherID))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, $"V.VOUCHER_ID='{voucherID}'");
				IsLead = false;
			}
			if (!string.IsNullOrWhiteSpace(phoneNumber))
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, string.Format("(ADDR.PHONE1='{0}' OR ADDR.PHONE2='{0}' OR ADDR.PHONE3='{0}' OR ADDR.MOBILE='{0}')", phoneNumber));
				QueryHelper.AddWhereCondition(leadWhereCondition, string.Format("(LADDR.PHONENUMBER='{0}' OR LADDR.PHONE2='{0}' OR LADDR.PHONE3='{0}' OR LADDR.MOBILENUMBER='{0}')", phoneNumber));
			}
			if (birthdate.HasValue)
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, string.Format("A.BIRTHDATE='{0:yyyy-MM-dd}'", birthdate));
				QueryHelper.AddWhereCondition(leadWhereCondition, string.Format("L.DATEOFBIRTH='{0:yyyy-MM-dd}'", birthdate));
			}
			if (IsLead.HasValue)
			{
				QueryHelper.AddWhereCondition(customerWhereCondition, string.Format("0={0}", IsLead.Value ? 1 : 0));
				QueryHelper.AddWhereCondition(leadWhereCondition, string.Format("1={0}", IsLead.Value ? 1 : 0));
			}

			StringBuilder sqlCommand = new StringBuilder();
			sqlCommand.Append(" SELECT A.COMPANY_CODE, A.DIVISION_CODE, AEXT.SHOP_CODE, A.CUSTOMER_CODE, NULL AS XID, FIRSTNAME, MIDDLENAME, LASTNAME, GENDER_CODE, BIRTHDATE, SALUTATION_CODE, A.STATUS_CODE, AEXT.TYPE_CODE, PREFERREDNAME, SOURCE_CODE, SUB_SOURCE_CODE, REF_SOURCE_CODE, 0 AS IS_LEAD, A.ROWGUID");
			sqlCommand.Append(" FROM CU_B_ADDRESS_BOOK A");
			sqlCommand.Append(" JOIN CU_B_ADDRESS ADDR ON A.COMPANY_CODE=ADDR.COMPANY_CODE AND A.DIVISION_CODE=ADDR.DIVISION_CODE AND A.CUSTOMER_CODE=ADDR.CUSTOMER_CODE");
			sqlCommand.Append(" JOIN CU_B_ADDRESS_BOOK_EXT_AUS AEXT ON A.COMPANY_CODE=AEXT.COMPANY_CODE AND A.DIVISION_CODE=AEXT.DIVISION_CODE AND A.CUSTOMER_CODE=AEXT.CUSTOMER_CODE");
			sqlCommand.Append(" LEFT JOIN CU_B_VOUCHER_EXT_AUS V ON A.COMPANY_CODE=V.COMPANY_CODE AND A.DIVISION_CODE=V.DIVISION_CODE AND A.CUSTOMER_CODE=V.CUSTOMER_CODE");
			if (customerWhereCondition.Length > 0)
				sqlCommand.Append(customerWhereCondition.ToString());
			sqlCommand.Append(" UNION ");
			sqlCommand.Append(" SELECT L.COMPANY_CODE, L.DIVISION_CODE, NULL AS SHOP_CODE, NULL AS CUSTOMER_CODE, L.XID, FIRSTNAME, MIDDLENAME, LASTNAME, GENDER, DATEOFBIRTH, SALUTATION, STATUS_CODE, FUNDINGTYPE, PREFERREDNAME, LEADSOURCE, LEADSUBSOURCE, REFERRALSOURCE, 1 AS IS_LEAD, L.ROWGUID");
			sqlCommand.Append(" FROM CU_B_LEAD_EXT_AUS L");
			sqlCommand.Append(" JOIN CU_B_LEAD_ADDRESS_EXT_AUS LADDR ON L.COMPANY_CODE=LADDR.COMPANY_CODE AND L.DIVISION_CODE=LADDR.DIVISION_CODE AND L.XID=LADDR.XID");
			if (leadWhereCondition.Length > 0)
				sqlCommand.Append(leadWhereCondition.ToString());

			IQueryable<LEAD_CUSTOMER> qryCustomers = DBContext.LeadAndCustomers.FromSql(sqlCommand.ToString());
			int RecordCount = qryCustomers.Count();

			List<CustomerLeadListItem> Result = new List<CustomerLeadListItem>();

			//foreach (LEAD_CUSTOMER Item in QueryHelper.GetPageItems<LEAD_CUSTOMER>(qryCustomers.Where(predicate), pageSize, pageNumber))
			if (SortAscending)
				qryCustomers = qryCustomers.OrderBy(E => E.LASTNAME).OrderBy(E => E.FIRSTNAME);
			else
				qryCustomers = qryCustomers.OrderByDescending(E => E.LASTNAME).OrderByDescending(E => E.FIRSTNAME);

			foreach (LEAD_CUSTOMER Item in QueryHelper.GetPageItems<LEAD_CUSTOMER>(qryCustomers, pageSize, pageNumber).ToArray())
			{
				CustomerLeadListItem ResultItem = EntityMapper.Map<CustomerLeadListItem, LEAD_CUSTOMER>(DBContext, Item);
				Result.Add(ResultItem);
			}

			return new QueryResult<CustomerLeadListItem>(pageSize, RecordCount, pageNumber, Result);
		}


		/// <summary>
		/// Search for customers with the given phone number
		/// </summary>
		/// <param name="PhoneNumber">Customer's phone number (exact match search performed)</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public ActionResult<IEnumerable<CustomerListItem>> ByPhoneNumber(string PhoneNumber)
		{
			if (string.IsNullOrWhiteSpace(PhoneNumber))
				throw new ArgumentNullException("PhoneNumber");

			var predicate = PredicateBuilder.New<CU_B_ADDRESS_BOOK>(false);
			predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE1 == PhoneNumber));
			predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE2 == PhoneNumber));
			predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.PHONE3 == PhoneNumber));
			predicate = predicate.Or(E => E.CU_B_ADDRESS.Any(A => A.MOBILE == PhoneNumber));

			List<CustomerListItem> Result = new List<CustomerListItem>();
			foreach (CU_B_ADDRESS_BOOK Item in DBContext.CU_B_ADDRESS_BOOK.Include(E => E.CU_B_ADDRESS).Where(predicate).Take(Settings.Value.MaxQueryResult))
			{
				CustomerListItem ResultItem = EntityMapper.Map<CustomerListItem, CU_B_ADDRESS_BOOK>(DBContext, Item, Item.CU_B_ADDRESS_BOOK_EXT_AUS);
				Result.Add(ResultItem);
			}

			return Result;
		}

		/// <summary>
		/// Given a customer ID returns all customer's audiograms
		/// </summary>
		/// <param name="id">The customer ID</param>
		/// <returns>Customer's audiograms</returns>
		[HttpGet("[action]/{id}")]
		public ActionResult<IEnumerable<AudiogramListItem>> Audiograms(string id)
		{
			List<AudiogramListItem> Result = new List<AudiogramListItem>();
			foreach (CU_B_AUDIOGRAM Item in DBContext.CU_B_AUDIOGRAM.Where(E => E.CUSTOMER_CODE == id).OrderByDescending(E => E.ACTIVITY_DATE).OrderByDescending(E => E.DT_INSERT).Take(Settings.Value.MaxQueryResult))
			{
				AudiogramListItem ListItem = new AudiogramListItem(Item);
				ListItem.LoadDescriptions(DBContext);
				Result.Add(ListItem);
			}

			return Result;
		}

		/// <summary>
		/// Get audiograms for a specific customer and activity date
		/// </summary>
		/// <param name="id">Customer ID</param>
		/// <param name="ActivityDate">Activity Date</param>
		/// <returns>Audiograms data</returns>
		[HttpGet("[action]")]
		public ActionResult<IEnumerable<AudiogramExtended>> Audiogram(string id, DateTime ActivityDate)
		{
			List<AudiogramExtended> Result = new List<AudiogramExtended>();
			foreach (CU_B_AUDIOGRAM Item in DBContext.CU_B_AUDIOGRAM.Where(E => E.CUSTOMER_CODE == id && E.ACTIVITY_DATE.Date == ActivityDate.Date).OrderByDescending(E => E.DT_INSERT).Take(Settings.Value.MaxQueryResult))
			{
				AudiogramExtended Audiogram = new AudiogramExtended(Item);
				Audiogram.LoadDescriptions(DBContext);
				Result.Add(Audiogram);
			}

			return Result;
		}

		/// <summary>
		/// Get Attachments list for a specific customer filtered by attachment type code (optional)
		/// </summary>
		/// <param name="id">Customer Code</param>
		/// <param name="attachmentTypeCode">Attachment Type Code (optional)</param>
		/// <returns>Attachment data</returns>
		[HttpGet("[action]/{id}")]
		public ActionResult<IEnumerable<AttachmentBase>> Attachments(string id, string attachmentTypeCode)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentNullException(nameof(id), "Customer id cannot be null");

			List<AttachmentBase> Result = new List<AttachmentBase>();
			var predicate = PredicateBuilder.New<CM_B_ATTACHMENT>(E => E.CUSTOMER_CODE == id);
			if (!string.IsNullOrWhiteSpace(attachmentTypeCode))
				predicate = predicate.And(E => E.ATTACHMENT_TYPE_CODE == attachmentTypeCode);
			foreach (CM_B_ATTACHMENT Item in DBContext.CM_B_ATTACHMENT.Where(predicate))
			{
				AttachmentBase I = EntityMapper.Map<AttachmentBase, CM_B_ATTACHMENT>(DBContext, Item);
				Result.Add(I);
			}

			return Result;
		}

		/// <summary>
		/// Get full attachment data
		/// </summary>
		/// <param name="id">Customer Code</param>
		/// <param name="rowGuid">Attachment RowGuid</param>
		/// <returns></returns>
		[HttpGet("[action]/{id}/{rowGuid}")]
		public ActionResult<Attachment> Attachments(string id, Guid rowGuid)
		{
			if (string.IsNullOrWhiteSpace(id) || rowGuid == Guid.Empty)
				throw new Exception("All parameters are needed to call this api");

			CM_B_ATTACHMENT Item = DBContext.CM_B_ATTACHMENT.FirstOrDefault(E => E.CUSTOMER_CODE == id && E.ROWGUID == rowGuid);
			if (Item == null)
				throw new NotFoundException($"No attachment found with rowGuid: {rowGuid}");

			Attachment Result = EntityMapper.Map<Attachment, CM_B_ATTACHMENT>(DBContext, Item);

			return Result;
		}

		/// <summary>
		/// Retrieve customer's notes
		/// </summary>
		/// <param name="id">Customer code</param>
		/// <param name="pageSize">Requested page size</param>
		/// <param name="pageNumber">Requested page index (Zero-based)</param>
		/// <returns></returns>
		[HttpGet("[action]/{id}")]
		public ActionResult<QueryResult<NoteListItem>> Notes(string id, int pageSize = 20, int pageNumber = 0)
		{
			List<NoteListItem> Result = new List<NoteListItem>();

			var predicate = PredicateBuilder.New<CU_B_NOTE>();
			predicate = predicate.And(E => E.CUSTOMER_CODE == id);

			var qryNotes = from Note in DBContext.CU_B_NOTE
										 orderby Note.NOTE_DATE descending, Note.NOTE_COUNTER ascending
										 select Note;

			int RecordCount = qryNotes.Where(predicate).Count();
			//.Include(E => E.SY_ACTIVITY_TYPE).Include(E => E.SY_DOCUMENT_TYPE)
			foreach (CU_B_NOTE Item in QueryHelper.GetPageItems<CU_B_NOTE>(qryNotes.Where(predicate), pageSize, pageNumber))
				Result.Add(EntityMapper.Map<NoteListItem, CU_B_NOTE>(DBContext, Item));

			return new QueryResult<NoteListItem>(pageSize, RecordCount, pageNumber, Result);
		}

		[HttpGet("Note/{rowGuid}")]
		public ActionResult<NoteListItem> NoteGet(Guid rowGuid)
		{
			CU_B_NOTE Item = DBContext.CU_B_NOTE.FirstOrDefault(E => E.ROWGUID == rowGuid);
			if (Item == null)
				throw new NotFoundException($"No note found with RowGuid:{rowGuid}");

			NoteListItem Result = EntityMapper.Map<NoteListItem, CU_B_NOTE>(DBContext, Item);

			return Result;
		}

		[HttpPost("Note")]
		public ActionResult<NoteListItem> NotePost([FromBody] NoteBase value)
		{
			if (value == null)
				throw new ArgumentNullException($"Argument value cannot be null");

			CU_B_NOTE Item = EntityMapper.CreateEntity<CU_B_NOTE>();

			EntityMapper.UpdateEntity(value, Item);

			Item.NOTE_DATE = DateTime.Today;
			CU_B_NOTE LastNote = DBContext.CU_B_NOTE.Where(E => E.CUSTOMER_CODE == Item.CUSTOMER_CODE && E.NOTE_DATE == Item.NOTE_DATE).OrderByDescending(E => E.NOTE_COUNTER).FirstOrDefault();
			Item.NOTE_COUNTER = LastNote != null ? LastNote.NOTE_COUNTER + 1 : 1; 

			value.SaveData<CU_B_NOTE>(DBContext, Item);

			DBContext.CU_B_NOTE.Add(Item);
			DBContext.SaveChanges();

			return NoteGet(Item.ROWGUID);
		}

		[HttpPut("Note/{rowGuid}")]
		public void NotePut(Guid rowGuid, [FromBody] NoteBase value)
		{
			if (value == null)
				throw new ArgumentNullException($"Argument value cannot be null");

			CU_B_NOTE Item = DBContext.CU_B_NOTE.SingleOrDefault(E => E.COMPANY_CODE == Settings.Value.CompanyCode && E.DIVISION_CODE == Settings.Value.DivisionCode && E.ROWGUID == rowGuid);
			if (Item == null)
				throw new NotFoundException($"No note found with RowGuid:{rowGuid}");

			EntityMapper.UpdateEntity(value, Item);

			value.SaveData<CU_B_NOTE>(DBContext, Item);

			DBContext.SaveChanges();
		}
	}
}
