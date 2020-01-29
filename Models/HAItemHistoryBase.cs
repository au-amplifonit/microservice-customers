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
	public class HAItemHistoryBase : ModelBase
	{
		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CU_B_HA_ITEM_HISTORY.PRODUCT_CODE))]
		public string ProductCode { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CU_B_HA_ITEM_HISTORY.SERIAL_NUMBER))]
		public string SerialNumber { get; set; }

		[JsonProperty(Order = -10)]
		[FieldMapper(nameof(CU_B_HA_ITEM_HISTORY.SIDE_CODE))]
		public string Side { get; set; }

		[JsonProperty(Order = -10)]
		public DateTime? FittingDate { get; set; }

		[JsonProperty(Order = -10)]
		public string SupplierCode { get; set; }



		public HAItemHistoryBase()
		{

		}

		public HAItemHistoryBase(CU_B_HA_ITEM_HISTORY Entity) : base(Entity.ROWGUID)
		{
			/*
			ProductCode = Entity.PRODUCT_CODE;
			SerialNumber = Entity.SERIAL_NUMBER;
			Side = Entity.SIDE_CODE;
			*/
		}

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);

			CustomersContext DBContext = (CustomersContext)context;
			if (entity is CU_B_HA_ITEM_HISTORY)
			{
				CU_B_HA_ITEM_HISTORY Item = (CU_B_HA_ITEM_HISTORY)entity;

				SupplierCode = Item.PD_S_PRODUCT.SUPPLIER_CODE;

				CU_B_HA_ITEM_HISTORY_EXT_AUS ItemExt = DBContext.CU_B_HA_ITEM_HISTORY_EXT_AUS.FirstOrDefault(E => E.COMPANY_CODE == Item.COMPANY_CODE && E.DIVISION_CODE == Item.DIVISION_CODE && E.CUSTOMER_CODE == Item.CUSTOMER_CODE && E.PRODUCT_CODE == Item.PRODUCT_CODE && E.SERIAL_NUMBER == Item.SERIAL_NUMBER);
				if (ItemExt != null)
					FittingDate = ItemExt.FITTING_DATE;
			}
		}
	}
}
