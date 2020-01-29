using Fox.Microservices.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models
{
	public class HAItemHistoryListItem : HAItemHistoryBase
	{
		public string ProductCommercialDescription { get; set; }
		public string ProductDescription { get; set; }
		public string SideDescription { get; set; }

		public HAItemHistoryListItem()
		{

		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);

			CustomersContext DBContext = (CustomersContext)context;
			if (entity is CU_B_HA_ITEM_HISTORY)
			{
				CU_B_HA_ITEM_HISTORY Item = (CU_B_HA_ITEM_HISTORY)entity;

				ProductDescription = Item.PD_S_PRODUCT?.PRODUCT_DESCR;
				SideDescription = Item.SY_SIDE?.SIDE_DESCR;
				PD_S_PRODUCT_EXT_AUS ProductExtData = DBContext.PD_S_PRODUCT_EXT_AUS.FirstOrDefault(E => E.DIVISION_CODE == Item.DIVISION_CODE && E.COMPANY_CODE == Item.COMPANY_CODE && E.PRODUCT_CODE == Item.PRODUCT_CODE);
				ProductCommercialDescription = ProductExtData?.PRODUCT_COMMER;
			}
		}
	}
}
