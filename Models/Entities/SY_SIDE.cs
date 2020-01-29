using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class SY_SIDE
    {
        public SY_SIDE()
        {
            CU_B_AUDIOGRAM = new HashSet<CU_B_AUDIOGRAM>();
            CU_B_HA_ITEM_HISTORY = new HashSet<CU_B_HA_ITEM_HISTORY>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SIDE_CODE { get; set; }
        public string SIDE_DESCR { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_AUDIOGRAM> CU_B_AUDIOGRAM { get; set; }
        public virtual ICollection<CU_B_HA_ITEM_HISTORY> CU_B_HA_ITEM_HISTORY { get; set; }
    }
}
