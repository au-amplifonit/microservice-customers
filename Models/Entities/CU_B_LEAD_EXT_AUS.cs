using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_LEAD_EXT_AUS
    {
        public CU_B_LEAD_EXT_AUS()
        {
            CU_B_LEAD_ADDRESS_EXT_AUS = new HashSet<CU_B_LEAD_ADDRESS_EXT_AUS>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string XID { get; set; }
        public DateTime? DATEOFBIRTH { get; set; }
        public string SALUTATION { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string PREFERREDNAME { get; set; }
        public string STATUS_CODE { get; set; }
        public string GENDER { get; set; }
        public string FUNDINGTYPE { get; set; }
        public string LEADSOURCE { get; set; }
        public string LEADSUBSOURCE { get; set; }
        public string REFERRALSOURCE { get; set; }
        public string LEADIMPORTSOURCE { get; set; }
        public bool? ONINTERNALDNC { get; set; }
        public DateTime? LEADEXPIRATIONDATE { get; set; }
        public string NOTES { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string LEADTYPE { get; set; }
        public string SOURCE_CUSTOMER_ID { get; set; }
        public string SOURCE_TYPE { get; set; }
        public bool FLG_PRIVACY { get; set; }
        public bool FLG_CONSENSUS { get; set; }
        public string COMMON_VAUCHER_ID { get; set; }

        public virtual CU_S_STATUS CU_S_STATUS { get; set; }
        public virtual ICollection<CU_B_LEAD_ADDRESS_EXT_AUS> CU_B_LEAD_ADDRESS_EXT_AUS { get; set; }
    }
}
