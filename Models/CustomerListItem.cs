using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models
{
	public class CustomerListItem : CustomerBase
	{
		public string GenderDescription { get; set; }  //SY_GENDER
		public string StatusDescription { get; set; }  //CU_S_STATUS
		public string SalutationDescription { get; set; }  //CU_S_SALUTATION
		public Address MainAddress { get; set; }
		public HAItemHistoryListItem[] LastHAItemHistory { get; set; }

		public CustomerListItem()
		{

		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			CustomersContext DBContext = (CustomersContext)context;
			GenderDescription = DBContext.SY_GENDER.FirstOrDefault(E => E.GENDER_CODE == GenderCode)?.GENDER_DESCR;
			SalutationDescription = DBContext.CU_S_SALUTATION.FirstOrDefault(E => E.SALUTATION_CODE == SalutationCode)?.SALUTATION_DESCR;
			StatusDescription = DBContext.CU_S_STATUS.FirstOrDefault(E => E.STATUS_CODE == StatusCode)?.STATUS_DESCR?.Trim();  //CU_S_STATUS


			if (entity is CU_B_ADDRESS_BOOK || (entity is LEAD_CUSTOMER && entity.IS_LEAD == 0))
			{
				CU_B_ADDRESS ADDR = DBContext.CU_B_ADDRESS.FirstOrDefault(E => E.CUSTOMER_CODE == ID && E.ADDRESS_COUNTER == 1);
				if (ADDR != null)
					MainAddress = new Address(ADDR);

				LastHAItemHistory = LoadLastHAItems(DBContext, entity);
			}
		}
	}
}
