using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_S_STATUS
    {
        public CU_S_STATUS()
        {
            CU_B_ADDRESS_BOOK = new HashSet<CU_B_ADDRESS_BOOK>();
            CU_B_LEAD_EXT_AUS = new HashSet<CU_B_LEAD_EXT_AUS>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string STATUS_CODE { get; set; }
        public string STATUS_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_ADDRESS_BOOK> CU_B_ADDRESS_BOOK { get; set; }
        public virtual ICollection<CU_B_LEAD_EXT_AUS> CU_B_LEAD_EXT_AUS { get; set; }
    }
}
