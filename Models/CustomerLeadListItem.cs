using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;

namespace Fox.Microservices.Customers.Models
{
	public class CustomerLeadListItem: CustomerListItem
	{
		[FieldMapper(nameof(LEAD_CUSTOMER.XID))]
		public string XID { get; set; }

		[FieldMapper(nameof(LEAD_CUSTOMER.IS_LEAD))]
		public bool IsLead { get; set; }

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			CustomersContext DBContext = (CustomersContext)context;

			if (IsLead)
			{
				CU_B_LEAD_ADDRESS_EXT_AUS ADDR = DBContext.CU_B_LEAD_ADDRESS_EXT_AUS.FirstOrDefault(E => E.XID == XID);
				if (ADDR != null)
					MainAddress = EntityMapper.Map<AddressExtended, CU_B_LEAD_ADDRESS_EXT_AUS>(DBContext, ADDR);
			}
		}
	}
}
