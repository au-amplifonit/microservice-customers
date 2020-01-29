using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Helpers;

namespace Fox.Microservices.Customers.Models
{
	public enum PreferredContactMethods
	{
		[EnumValue("01")]
		Home,
		[EnumValue("02")]
		Mobile,
		[EnumValue("04")]
		EMail,
		[EnumValue("05")]
		Any
	}

	public class Customer : CustomerBase
	{
		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.MIDDLENAME))]
		public string MiddleName { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.PREFERREDNAME))]
		public string PreferredName { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.OTHERCONTACT_FIRSTNAME))]
		public string OtherContact_Firstname { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.OTHERCONTACT_LASTNAME))]
		public string OtherContact_Lastname { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.RELATION), typeof(CU_B_ADDRESS_BOOK))]
		public string Relation { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.BIRTHLOCATION))]
		public string BirthPlace { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.TAX_ID_NUMBER))]
		public string Tax_ID_Number { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.TITLE_CODE))]
		public string TitleCode { get; set; }  //CU_S_TITLE

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FLG_PRIVACYPERSDATA), typeof(CU_B_ADDRESS_BOOK))]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.FLG_PRIVACY), typeof(CU_B_LEAD_EXT_AUS))]
		public bool? AllowPrivacy { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FLG_SENSDATA), typeof(CU_B_ADDRESS_BOOK))]
		public bool? AllowSensData { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FLG_ADVERTISING), typeof(CU_B_ADDRESS_BOOK))]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.FLG_CONSENSUS), typeof(CU_B_LEAD_EXT_AUS))]
		public bool? AllowAdvertising { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FLG_PROFILING), typeof(CU_B_ADDRESS_BOOK))]
		public bool? AllowProfiling { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.DT_UPDATE_STATUS), typeof(CU_B_ADDRESS_BOOK))]
		public DateTime? StatusUpdateDate { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.CATEGORY_CODE), typeof(CU_B_ADDRESS_BOOK), DefaultValue = "CL")]
		public string CategoryCode { get; set; }  //CU_S_CATEGORY

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.CUSTOMER_TYPE_CODE), typeof(CU_B_ADDRESS_BOOK), DefaultValue = "QL")]
		[FieldMapper(nameof(CU_B_LEAD_EXT_AUS.LEADTYPE), typeof(CU_B_LEAD_EXT_AUS), DefaultValue = "QL")]
		public string CustomerTypeCode { get; set; }  //CU_S_TYPE

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.DT_UPDATE_CUSTOMERTYPE), typeof(CU_B_ADDRESS_BOOK))]
		public DateTime? CustomerTypeUpdateDate { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.OCCUPATION_CODE), typeof(CU_B_ADDRESS_BOOK))]
		public string OccupationCode { get; set; }  //CU_S_OCCUPATION

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.OCCUPATION_OTHER), typeof(CU_B_ADDRESS_BOOK))]
		public string OccupationOther { get; set; }  //CU_S_OCCUPATION

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.FLG_RETIRED), typeof(CU_B_ADDRESS_BOOK))]
		public bool IsRetired { get; set; }

		public string PracticeCode { get; set; }
		public string PractitionerCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK.LANGUAGE_CODE), typeof(CU_B_ADDRESS_BOOK), DefaultValue = "en-US")]
		public string LanguageCode { get; set; }
		public PreferredContactMethods PreferredContactMethod { get; set; } = PreferredContactMethods.Any;
		public bool IsOtherContactPreferred { get; set; } = false;
		public string PreferredTimeOfContactCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS_BOOK_EXT_AUS.IDCALL), typeof(CU_B_ADDRESS_BOOK_EXT_AUS))]
		public string CallID { get; set; }


		public Address[] Addresses { get; set; }


		public Customer()
		{

		}

		public Customer(CU_B_ADDRESS_BOOK Entity) : base(Entity)
		{
			MiddleName = Entity.MIDDLENAME;
			OtherContact_Firstname = Entity.OTHERCONTACT_FIRSTNAME;
			OtherContact_Lastname = Entity.OTHERCONTACT_LASTNAME;
			Relation = Entity.RELATION;
			GenderCode = Entity.GENDER_CODE;
			BirthPlace = Entity.BIRTHLOCATION;
			Tax_ID_Number = Entity.TAX_ID_NUMBER;
			TitleCode = Entity.TITLE_CODE;  //CU_S_TITLE
			SalutationCode = Entity.SALUTATION_CODE;  //CU_S_SALUTATION
			AllowPrivacy = Entity.FLG_PRIVACYPERSDATA == "Y";
			AllowSensData = Entity.FLG_SENSDATA == "Y";
			AllowAdvertising = Entity.FLG_ADVERTISING == "Y";
			AllowProfiling = Entity.FLG_PROFILING == "Y";
			StatusUpdateDate = Entity.DT_UPDATE_STATUS;
			CategoryCode = Entity.CATEGORY_CODE;  //CU_S_CATEGORY
			CustomerTypeCode = Entity.CUSTOMER_TYPE_CODE;  //CU_S_TYPE
			CustomerTypeUpdateDate = Entity.DT_UPDATE_CUSTOMERTYPE;
			OccupationCode = Entity.OCCUPATION_CODE;  //CU_S_OCCUPATION
			OccupationOther = Entity.OCCUPATION_OTHER;  //CU_S_OCCUPATION
			IsRetired = Entity.FLG_RETIRED == "Y";
			PracticeCode = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.PRACTICE_CODE;
			PractitionerCode = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.PRACTITIONER_CODE;
			PreferredName = Entity.CU_B_ADDRESS_BOOK_EXT_AUS?.PREFERREDNAME;
		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);

			if (entity is CU_B_ADDRESS_BOOK)
			{
				CustomersContext DBContext = (CustomersContext)context;
				CU_B_PROFILE_ATTRIBUTE_LOOKUP ProfileAttribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "SMF");
				PreferredContactMethod = EnumHelper.GetEnumFromValue<PreferredContactMethods>(ProfileAttribute?.VALUE_CODE, PreferredContactMethods.Any);
				CU_B_PROFILE_ATTRIBUTE_LOOKUP Attribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "PCT");
				IsOtherContactPreferred = Attribute?.VALUE_CODE == "02";
				CU_B_PROFILE_ATTRIBUTE_LOOKUP PreferredTimeOfContactAttribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "CTP");
				PreferredTimeOfContactCode = PreferredTimeOfContactAttribute?.VALUE_CODE ?? "06";

				List<Address> Addrs = new List<Address>();
				foreach (CU_B_ADDRESS Item in ((CU_B_ADDRESS_BOOK)entity).CU_B_ADDRESS.OrderBy(E => E.ADDRESS_COUNTER))
					try
					{
						Addrs.Add(new Address(Item));
					}
					catch
					{
					}
				Addresses = Addrs.ToArray();
			}
			else if (entity is CU_B_LEAD_EXT_AUS)
			{
				CustomersContext DBContext = (CustomersContext)context;
				string XID = entity.XID;
				List<Address> Addrs = new List<Address>();
				int AddressCounter = 1;
				foreach (CU_B_LEAD_ADDRESS_EXT_AUS Item in DBContext.CU_B_LEAD_ADDRESS_EXT_AUS.Where(E => E.XID == XID).OrderBy(E => E.ADDRESSTYPE))
					try
					{
						Address address = EntityMapper.Map<Address, CU_B_LEAD_ADDRESS_EXT_AUS>(DBContext, Item);
						if (Item.ADDRESSTYPE == "1") //Residential
						{
							address.IsHomeAddress = true;
							address.IsMailingDefault = true;
							address.IsInvoiceDefault = true;
						}
						else if (Item.ADDRESSTYPE == "2") //Postal
						{
							address.IsHomeAddress = false;
							address.IsMailingDefault = true;
						}

						address.AddressCounter = AddressCounter++;
						Addrs.Add(address);
					}
					catch
					{
					}

				//Ensure existance of the home address
				if (Addrs.Count == 1 || (Addrs.Count > 0 && !Addrs.Any(E => E.IsHomeAddress)))
				{
					Addrs[0].IsHomeAddress = true;
					Addrs[0].IsMailingDefault = true;
					Addrs[0].IsInvoiceDefault = true;
				}

				Address HomeAddress = Addrs.FirstOrDefault(E => E.IsHomeAddress);
				Address MailingAddress = Addrs.FirstOrDefault(E => !E.IsHomeAddress && E.IsMailingDefault);
				HomeAddress.IsMailingDefault = (MailingAddress == null);

				Addresses = Addrs.ToArray();
			}
		}

		public override void SaveData<T>(DbContext context, dynamic entity)
		{
			base.SaveData<T>(context, (T)entity);
			CustomersContext DBContext = (CustomersContext)context;
			CU_B_PROFILE Profile = DBContext.CU_B_PROFILE.FirstOrDefault(E => E.CUSTOMER_CODE == ID);
			if (Profile == null)
			{
				Profile = EntityMapper.CreateEntity<CU_B_PROFILE>();
				Profile.CUSTOMER_CODE = ID;
				DBContext.CU_B_PROFILE.Add(Profile);
			}
			Profile.FLG_OTHERCONTACT = IsOtherContactPreferred ? "Y" : "N";

			CU_B_PROFILE_ATTRIBUTE_LOOKUP ProfileAttribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "SMF");
			if (ProfileAttribute != null)
				DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Remove(ProfileAttribute);

			ProfileAttribute = EntityMapper.CreateEntity<CU_B_PROFILE_ATTRIBUTE_LOOKUP>();
			ProfileAttribute.CUSTOMER_CODE = ID;
			ProfileAttribute.ATTRIBUTE_CODE = "SMF";
			ProfileAttribute.VALUE_CODE = EnumHelper.GetEnumValue<PreferredContactMethods>(PreferredContactMethod);
			DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Add(ProfileAttribute);

			CU_B_PROFILE_ATTRIBUTE_LOOKUP OtheContactIsPrimaryAttribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "PCT");
			if (OtheContactIsPrimaryAttribute != null)
				DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Remove(OtheContactIsPrimaryAttribute);

			OtheContactIsPrimaryAttribute = EntityMapper.CreateEntity<CU_B_PROFILE_ATTRIBUTE_LOOKUP>();
			OtheContactIsPrimaryAttribute.CUSTOMER_CODE = ID;
			OtheContactIsPrimaryAttribute.ATTRIBUTE_CODE = "PCT";
			OtheContactIsPrimaryAttribute.VALUE_CODE = IsOtherContactPreferred ? "02" : "01";
			DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Add(OtheContactIsPrimaryAttribute);

			CU_B_PROFILE_ATTRIBUTE_LOOKUP PreferredTimeOfContactAttribute = DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ATTRIBUTE_CODE == "CTP");
			if (PreferredTimeOfContactAttribute != null)
				DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Remove(PreferredTimeOfContactAttribute);

			PreferredTimeOfContactAttribute = EntityMapper.CreateEntity<CU_B_PROFILE_ATTRIBUTE_LOOKUP>();
			PreferredTimeOfContactAttribute.CUSTOMER_CODE = ID;
			PreferredTimeOfContactAttribute.ATTRIBUTE_CODE = "CTP";
			PreferredTimeOfContactAttribute.VALUE_CODE = PreferredTimeOfContactCode  ?? "06";
			DBContext.CU_B_PROFILE_ATTRIBUTE_LOOKUP.Add(PreferredTimeOfContactAttribute);
		}
	}
}
