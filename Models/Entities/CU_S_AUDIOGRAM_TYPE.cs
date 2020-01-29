using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_S_AUDIOGRAM_TYPE
    {
        public CU_S_AUDIOGRAM_TYPE()
        {
            CU_B_AUDIOGRAM = new HashSet<CU_B_AUDIOGRAM>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public short AUDIOGRAM_TYPE_CODE { get; set; }
        public string AUDIOGRAM_TYPE_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_AUDIOGRAM> CU_B_AUDIOGRAM { get; set; }
    }
}
