using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_LEAD_ADDRESS_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string XID { get; set; }
        public string ADDRESSTYPE { get; set; }
        public string ADDRESSLINE1 { get; set; }
        public string ADDRESSLINE2 { get; set; }
        public string ADDRESSLINE3 { get; set; }
        public string ADDRESSLINE4 { get; set; }
        public string SUBURB { get; set; }
        public string STATECODE { get; set; }
        public string ZIPCODE { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string PHONENUMBER { get; set; }
        public string MOBILENUMBER { get; set; }
        public string EMAIL { get; set; }
        public string PHONE2 { get; set; }
        public string PHONE3 { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CU_B_LEAD_EXT_AUS CU_B_LEAD_EXT_AUS { get; set; }
    }
}
