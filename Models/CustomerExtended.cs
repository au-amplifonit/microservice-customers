using Fox.Microservices.Common.Data.Helpers;
using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Helpers;

namespace Fox.Microservices.Customers.Models
{
	public class CustomerExtended : Customer
	{
		[JsonProperty(Order = 1)]
		public string GenderDescription { get; set; }

		[JsonProperty(Order = 1)]
		public string TitleDescription { get; set; } //CU_S_TITLE

		[JsonProperty(Order = 1)]
		public string SalutationDescription { get; set; }  //CU_S_SALUTATION

		[JsonProperty(Order = 1)]
		public string StatusDescription { get; set; }  //CU_S_STATUS

		[JsonProperty(Order = 1)]
		public string CategoryDescription { get; set; }  //CU_S_CATEGORY

		[JsonProperty(Order = 1)]
		public string CustomerTypeDescription { get; set; }  //CU_S_TYPE

		[JsonProperty(Order = 1)]
		public string OccupationDescription { get; set; }  //CU_S_OCCUPATION
		[JsonProperty(Order = 1)]
		public string LanguageDescription { get; set; }
		[JsonProperty(Order = 1)]
		public string PreferredTimeOfContactDescription { get; set; }
		[JsonProperty(Order = 1)]
		public string ShopDescription { get; set; }  //CM_B_SHOP

		[JsonProperty(Order = 1)]
		public HAItemHistoryListItem[] LastHAItemHistory { get; set; }


		public CustomerExtended()
		{

		}

		public CustomerExtended(CU_B_ADDRESS_BOOK Entity) : base(Entity)
		{
		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			if (entity is CU_B_ADDRESS_BOOK)
			{
				CustomersContext DBContext = (CustomersContext)context;
				GenderDescription = entity.SY_GENDER?.GENDER_DESCR;
				TitleDescription = entity.CU_S_TITLE?.TITLE_DESCR; //CU_S_TITLE
				SalutationDescription = entity.CU_S_SALUTATION?.SALUTATION_DESCR;  //CU_S_SALUTATION
				StatusDescription = entity.CU_S_STATUS?.STATUS_DESCR;  //CU_S_STATUS
				CategoryDescription = entity.CU_S_CATEGORY?.CATEGORY_DESCR;  //CU_S_CATEGORY
				CustomerTypeDescription = entity.CU_S_TYPE?.TYPE_DESCR;  //CU_S_TYPE
				OccupationDescription = entity.CU_S_OCCUPATION?.OCCUPATION_DESCR;  //CU_S_OCCUPATION
				ShopDescription = entity.CU_B_ADDRESS_BOOK_EXT_AUS?.CM_B_SHOP?.SHOP_DESCR;  
				LanguageDescription = DBContext.SY_LANGUAGE.FirstOrDefault(E => E.LANGUAGE_CODE == LanguageCode)?.LANGUAGE_DESCR;
				PreferredTimeOfContact preferredTimeOfContact = EnumHelper.GetEnumFromValue<PreferredTimeOfContact>(PreferredTimeOfContactCode, PreferredTimeOfContact.NoPreference);
				PreferredTimeOfContactDescription = EnumHelper.GetDescription<PreferredTimeOfContact>(preferredTimeOfContact);

				LastHAItemHistory = LoadLastHAItems((CustomersContext)context, entity);
			}
			else if (entity is CU_B_LEAD_EXT_AUS)
			{
				CustomersContext DBContext = (CustomersContext)context;
				CU_B_LEAD_EXT_AUS lead = (CU_B_LEAD_EXT_AUS)entity;

				GenderDescription = DBContext.SY_GENDER.FirstOrDefault(E => E.GENDER_CODE == lead.GENDER)?.GENDER_DESCR;
				//TitleDescription = entity.CU_S_TITLE?.TITLE_DESCR; //Not available in leads
				SalutationDescription = DBContext.CU_S_SALUTATION.FirstOrDefault(E => E.SALUTATION_CODE == lead.SALUTATION)?.SALUTATION_DESCR;  //CU_S_SALUTATION
				StatusDescription = DBContext.CU_S_STATUS.FirstOrDefault(E => E.STATUS_CODE == lead.STATUS_CODE)?.STATUS_DESCR;  //CU_S_STATUS
				//CategoryDescription = DBContext.CU_S_CATEGORY.FirstOrDefault(E => E.CATEGORY_CODE == lead.)?.CATEGORY_DESCR;  //Not available in leads
				CustomerTypeDescription = DBContext.CU_S_TYPE.FirstOrDefault(E => E.TYPE_CODE == lead.LEADTYPE)?.TYPE_DESCR;  //CU_S_TYPE
				//OccupationDescription = entity.CU_S_OCCUPATION?.OCCUPATION_DESCR;  //Not available in leads
				//ShopDescription = entity.CU_B_ADDRESS_BOOK_EXT_AUS?.CM_B_SHOP?.SHOP_DESCR;  //Not available in leads
			}
		}
	}
}
