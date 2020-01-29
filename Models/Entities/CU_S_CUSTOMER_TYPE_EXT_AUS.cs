using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_S_CUSTOMER_TYPE_EXT_AUS
    {
        public CU_S_CUSTOMER_TYPE_EXT_AUS()
        {
            CU_B_ADDRESS_BOOK_EXT_AUS = new HashSet<CU_B_ADDRESS_BOOK_EXT_AUS>();
            CU_B_HA_ITEM_HISTORY_EXT_AUS = new HashSet<CU_B_HA_ITEM_HISTORY_EXT_AUS>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string TYPE_CODE { get; set; }
        public string TYPE_DESCR { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_ADDRESS_BOOK_EXT_AUS> CU_B_ADDRESS_BOOK_EXT_AUS { get; set; }
        public virtual ICollection<CU_B_HA_ITEM_HISTORY_EXT_AUS> CU_B_HA_ITEM_HISTORY_EXT_AUS { get; set; }
    }
}
