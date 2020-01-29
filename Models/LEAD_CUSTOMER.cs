using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Entities
{
	public class LEAD_CUSTOMER
	{
		public string COMPANY_CODE { get; set; }
		public string DIVISION_CODE { get; set; }
		public string SHOP_CODE { get; set; }
		public string CUSTOMER_CODE { get; set; }
		public string FIRSTNAME { get; set; }
		public string MIDDLENAME { get; set; }
		public string LASTNAME { get; set; }
		public string GENDER_CODE { get; set; }
		public DateTime? BIRTHDATE { get; set; }
		public string SALUTATION_CODE { get; set; }
		public string STATUS_CODE { get; set; }
		public string TYPE_CODE { get; set; }
		public string PREFERREDNAME { get; set; }
		public string SOURCE_CODE { get; set; }
		public string SUB_SOURCE_CODE { get; set; }
		public string REF_SOURCE_CODE { get; set; }
		//public string NOTES { get; set; }
		public int IS_LEAD { get; set; }
		public string XID { get; set; }
		public Guid ROWGUID { get; set; }

	}
}
