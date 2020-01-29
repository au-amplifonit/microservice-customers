using Fox.Microservices.Customers.Helpers;
using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models
{
	public class CustomerBase : ModelBase
	{
		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.CUSTOMER_CODE), ReadOnly = true)]
		[JsonProperty(Order = -10)]
		public string ID { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FIRSTNAME))]
		[JsonProperty(Order = -10)]
		public string Firstname { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.LASTNAME))]
		[JsonProperty(Order = -10)]
		public string Lastname { get; set; }
		[JsonProperty(Order = -10)]

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.GENDER_CODE))]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.GENDER), typeof(CU_B_LEAD_EXT_AUS))]
		public string GenderCode { get; set; }  //SY_GENDER

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.SALUTATION_CODE))]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.SALUTATION), typeof(CU_B_LEAD_EXT_AUS))]
		[JsonProperty(Order = -10)]
		public string SalutationCode { get; set; }  //CU_S_SALUTATION
		[JsonProperty(Order = -10)]

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.BIRTHDATE))]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.DATEOFBIRTH), typeof(CU_B_LEAD_EXT_AUS))]
		public DateTime? Birthday { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.TYPE_CODE), typeof(CU_B_ADDRESS_BOOK_EXT_AUS), DefaultValue = "PVT")]
		[FieldMapper(nameof(LEAD_CUSTOMER.TYPE_CODE), typeof(LEAD_CUSTOMER), DefaultValue = "PVT")]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.FUNDINGTYPE), typeof(CU_B_LEAD_EXT_AUS), DefaultValue = "PVT")]
		[JsonProperty(Order = -10)]
		public string FundingType { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.STATUS_CODE))]
		[JsonProperty(Order = -10)]
		public string StatusCode { get; set; }  //CU_S_STATUS

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.SHOP_CODE))]
		[JsonProperty(Order = -10)]
		public string ShopCode { get; set; }  

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.PRACTICE_CODE))]
		[JsonProperty(Order = -10)]
		public string PracticeCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.PRACTITIONER_CODE))]
		[JsonProperty(Order = -10)]
		public string PractitionerCode { get; set; }

		[JsonProperty(Order = -10)]
		public string PracticeName { get; set; }

		[JsonProperty(Order = -10)]
		public string PractitionerNumber { get; set; }

		[JsonProperty(Order = -10)]
		public string PractitionerName { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.SOURCE_CODE))]
		[JsonProperty(Order = -10)]
		public string SourceCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.SUB_SOURCE_CODE))]
		[JsonProperty(Order = -10)]
		public string SubSourceCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.REF_SOURCE_CODE))]
		[JsonProperty(Order = -10)]
		public string ReferralSourceCode { get; set; }

		[JsonProperty(Order = -10)]
		public int? Age
		{
			get
			{
				if (!Birthday.HasValue)
					return null;

				return CustomerHelper.CalculatAge(Birthday.Value);
			}
		}


		public CustomerBase()
		{

		}

		public CustomerBase(CU_B_ADDRESS_BOOK Entity) : base(Entity.ROWGUID)
		{
			/*
			ID = Entity.CUSTOMER_CODE;
			Firstname = Entity.FIRSTNAME;
			Lastname = Entity.LASTNAME;
			Birthday = Entity.BIRTHDATE;
			FundingType = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.TYPE_CODE;
			StatusCode = Entity.STATUS_CODE;  //CU_S_STATUS
			SalutationCode = Entity.SALUTATION_CODE;
			GenderCode = Entity.GENDER_CODE;
			PracticeCode = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.PRACTICE_CODE;
			PractitionerCode = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.PRACTITIONER_CODE;
			*/
		}

		protected HAItemHistoryListItem[] LoadLastHAItems(CustomersContext ADBContext, dynamic entity)
		{
			List<HAItemHistoryListItem> HAItems = new List<HAItemHistoryListItem>();

			string CUSTOMER_CODE = entity.CUSTOMER_CODE;
			string COMPANY_CODE = entity.COMPANY_CODE;
			string DIVISION_CODE = entity.DIVISION_CODE;

			var qryItem = from HAItem in ADBContext.CU_B_HA_ITEM_HISTORY
												join HAItemExt in ADBContext.CU_B_HA_ITEM_HISTORY_EXT_AUS
													on new { HAItem.COMPANY_CODE, HAItem.DIVISION_CODE, HAItem.CUSTOMER_CODE, HAItem.PRODUCT_CODE, HAItem.SERIAL_NUMBER } equals new { HAItemExt.COMPANY_CODE, HAItemExt.DIVISION_CODE, HAItemExt.CUSTOMER_CODE, HAItemExt.PRODUCT_CODE, HAItemExt.SERIAL_NUMBER }
												where HAItem.COMPANY_CODE == COMPANY_CODE && HAItem.DIVISION_CODE == DIVISION_CODE && HAItem.CUSTOMER_CODE == CUSTOMER_CODE && HAItem.ITEM_STATUS_CODE != "C"
												orderby HAItemExt.FITTING_DATE descending
												select new { Data = HAItem, Ext = HAItemExt };

			var LeftItem = qryItem.FirstOrDefault(E => E.Data.SIDE_CODE == "L");
			var RightItem = qryItem.FirstOrDefault(E => E.Data.SIDE_CODE == "R");
			if (LeftItem != null)
			{
				HAItemHistoryListItem ListItem = EntityMapper.Map<HAItemHistoryListItem, CU_B_HA_ITEM_HISTORY>(ADBContext, LeftItem.Data);
				HAItems.Add(ListItem);
			}

			if (RightItem != null)
			{
				HAItemHistoryListItem ListItem = EntityMapper.Map<HAItemHistoryListItem, CU_B_HA_ITEM_HISTORY>(ADBContext, RightItem.Data);
				HAItems.Add(ListItem);
			}

			return HAItems.ToArray();
		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			if (entity is CU_B_ADDRESS_BOOK)
			{
				CustomersContext DBContext = (CustomersContext)context;
				if (!string.IsNullOrWhiteSpace(PracticeCode))
				{
					CM_S_MP_DETAILS_EXT_AUS PractitionerDetails = DBContext.CM_S_MP_DETAILS_EXT_AUS.FirstOrDefault(E => E.PRACTICE_CODE == PracticeCode && E.PRACTITIONER_CODE == PractitionerCode);
					CM_S_PRACTICE_DETAILS_EXT_AUS PracticeDetails = DBContext.CM_S_PRACTICE_DETAILS_EXT_AUS.FirstOrDefault(E => E.PRACTICE_CODE == PracticeCode);
					PracticeName = PracticeDetails?.PRACTICE_NAME;
					PractitionerName = PractitionerDetails?.PRACTITIONER_NAME;
					PractitionerNumber = PractitionerDetails?.PRACTITIONER_NUMBER;
				}
			}
		}
	}
}
