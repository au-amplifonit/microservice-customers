using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_PROFILE
    {
        public CU_B_PROFILE()
        {
            CU_B_PROFILE_ATTRIBUTE_LOOKUP = new HashSet<CU_B_PROFILE_ATTRIBUTE_LOOKUP>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string FLG_TV { get; set; }
        public short? HOURS_USAGE_TV { get; set; }
        public string FLG_NEWSP { get; set; }
        public string FLG_PUBLICTRANSPORT { get; set; }
        public string FLG_CAR { get; set; }
        public string FLG_TRAVEL { get; set; }
        public string FLG_PHONE { get; set; }
        public string FLG_SMS { get; set; }
        public string FLG_EMAIL { get; set; }
        public string FLG_INTERNET { get; set; }
        public string FLG_MOBILE { get; set; }
        public string FLG_OTHERCONTACT { get; set; }
        public string OTHERHOBBY { get; set; }
        public string LIVEWITH_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual ICollection<CU_B_PROFILE_ATTRIBUTE_LOOKUP> CU_B_PROFILE_ATTRIBUTE_LOOKUP { get; set; }
    }
}
