using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class SY_ACTIVITY_TYPE
    {
        public SY_ACTIVITY_TYPE()
        {
            CU_B_ACTIVITY = new HashSet<CU_B_ACTIVITY>();
            CU_B_NOTE = new HashSet<CU_B_NOTE>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string ACTIVITY_TYPE_CODE { get; set; }
        public string ACTIVITY_TYPE_DESCR { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPE { get; set; }
        public virtual ICollection<CU_B_ACTIVITY> CU_B_ACTIVITY { get; set; }
        public virtual ICollection<CU_B_NOTE> CU_B_NOTE { get; set; }
    }
}
