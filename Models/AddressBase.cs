using Fox.Microservices.Customers.Helpers;
using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Helpers;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models
{

	public class AddressBase : ModelBase
	{
		[FieldMapper(nameof(CU_B_ADDRESS.CUSTOMER_CODE), typeof(CU_B_ADDRESS), ReadOnly = true)]
		[FieldMapper(nameof(CU_B_ADDRESS_EXT_AUS.CUSTOMER_CODE), typeof(CU_B_ADDRESS_EXT_AUS), ReadOnly = true)]
		public string CustomerCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.ADDRESS_COUNTER), typeof(CU_B_ADDRESS), ReadOnly = true)]
		[FieldMapper(nameof(CU_B_ADDRESS_EXT_AUS.ADDRESS_COUNTER), typeof(CU_B_ADDRESS_EXT_AUS), ReadOnly = true)]
		public int AddressCounter { get; set; }
		public bool IsHomeAddress { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.FLG_LETTER_DEFAULT))]
		public bool IsMailingDefault { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.FLG_INVOICE_DEFAULT))]
		public bool IsInvoiceDefault { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.FLG_OTHER_CONTACT))]
		public bool IsOtherContact { get; set; }

		[FieldMapper("ADDRESS_LINE", IsArray = true, ArrayMaxRank = 4)]
		[FieldMapper("ADDRESSLINE", typeof(CU_B_LEAD_ADDRESS_EXT_AUS), IsArray = true, ArrayMaxRank = 4)]
		public string[] Address { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.COUNTRY_CODE))]
		[FieldMapper(nameof(CU_B_LEAD_ADDRESS_EXT_AUS.COUNTRY_CODE), typeof(CU_B_LEAD_ADDRESS_EXT_AUS))]
		[FieldMapper(nameof(CM_S_CITY_BOOK.COUNTRY_CODE), typeof(CM_S_CITY_BOOK), DefaultValue = "AUS")]
		public string CountryCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.AREA_CODE))]
		[FieldMapper(nameof(CM_S_CITY_BOOK.COUNTRY_CODE), typeof(CM_S_CITY_BOOK))]
		public string AreaCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.ZIP_CODE))]
		[FieldMapper(nameof(CU_B_LEAD_ADDRESS_EXT_AUS.ZIPCODE), typeof(CU_B_LEAD_ADDRESS_EXT_AUS))]
		[FieldMapper(nameof(CM_S_CITY_BOOK.ZIP_CODE), typeof(CM_S_CITY_BOOK))]
		public string ZipCode { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.CITY_NAME))]
		[FieldMapper(nameof(CU_B_LEAD_ADDRESS_EXT_AUS.SUBURB), typeof(CU_B_LEAD_ADDRESS_EXT_AUS))]
		[FieldMapper(nameof(CM_S_CITY_BOOK.CITY_NAME), typeof(CM_S_CITY_BOOK))]
		public string City { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.LOCALITY))]
		public string Locality { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.PO_BOX))]
		public string POBox { get; set; }

		[FieldMapper("PHONE", typeof(CU_B_ADDRESS), IsArray = true, ArrayMaxRank = 3)]
		public string[] Phones { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.MOBILE))]
		[FieldMapper("MOBILENUMBER", typeof(CU_B_LEAD_ADDRESS_EXT_AUS))]
		public string Mobile { get; set; }

		[FieldMapper(nameof(CU_B_ADDRESS.EMAIL))]
		public string EMail { get; set; }

		public AddressBase()
		{
		}

		public AddressBase(CU_B_ADDRESS Entity) : base(Entity.ROWGUID)
		{
			CustomerCode = Entity.CUSTOMER_CODE;
			AddressCounter = Entity.ADDRESS_COUNTER;
			IsHomeAddress = (AddressCounter == 1);
			IsMailingDefault = (Entity.FLG_LETTER_DEFAULT == "Y");
			IsInvoiceDefault = (Entity.FLG_INVOICE_DEFAULT == "Y");
			IsOtherContact = (Entity.FLG_OTHER_CONTACT == "Y");
			Address = new string[] { Entity.ADDRESS_LINE1, Entity.ADDRESS_LINE2, Entity.ADDRESS_LINE3, Entity.ADDRESS_LINE4 };
			CountryCode = Entity.COUNTRY_CODE;
			AreaCode = Entity.AREA_CODE;
			ZipCode = Entity.ZIP_CODE;
			City = Entity.CITY_NAME;
			Locality = Entity.LOCALITY;
			POBox = Entity.PO_BOX;
			Phones = new string[] { Entity.PHONE1, Entity.PHONE2, Entity.PHONE3 };
			Mobile = Entity.MOBILE;
			EMail = Entity.EMAIL;
		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);

			if (entity is CU_B_ADDRESS)
			{
				IsHomeAddress = (entity.ADDRESS_COUNTER == 1);
			}
			else if (entity is CU_B_LEAD_ADDRESS_EXT_AUS)
			{
				Phones = new string[] { entity.PHONENUMBER, entity.PHONE2, entity.PHONE3 };
			}
		}
	}	
}
