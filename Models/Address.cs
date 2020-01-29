using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;

namespace Fox.Microservices.Customers.Models
{
	public class Address : AddressBase
	{
		[FieldMapper(nameof(CU_B_ADDRESS_EXT_AUS.FLG_HOME_VISIT_DEFAULT), typeof(CU_B_ADDRESS_EXT_AUS))]
		[JsonProperty(Order = 0)]
		public bool IsHomeVisitDefault { get; set; }
		[JsonProperty(Order = 0)]
		[FieldMapper(nameof(CU_B_ADDRESS_EXT_AUS.HOMEVISIT_CONTACTNAME), typeof(CU_B_ADDRESS_EXT_AUS))]
		public string HomeVisitContactName { get; set; }

		[JsonProperty(Order = 0)]
		[FieldMapper(nameof(CU_B_ADDRESS_EXT_AUS.STATE_CODE), typeof(CU_B_ADDRESS_EXT_AUS))]
		[FieldMapper(nameof(CU_B_LEAD_ADDRESS_EXT_AUS.STATECODE), typeof(CU_B_LEAD_ADDRESS_EXT_AUS))]
		public string StateCode { get; set; }

		public Address()
		{
		}

		public Address(CU_B_ADDRESS Entity) : base(Entity)
		{
			try
			{
				IsHomeVisitDefault = Entity.CU_B_ADDRESS_EXT_AUS?.FLG_HOME_VISIT_DEFAULT == "Y";
				HomeVisitContactName = Entity.CU_B_ADDRESS_EXT_AUS?.HOMEVISIT_CONTACTNAME;
				StateCode = Entity.CU_B_ADDRESS_EXT_AUS?.STATE_CODE;
			}
			catch
			{
			}
		}
	}
}