using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_ADDRESS_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public int ADDRESS_COUNTER { get; set; }
        public string FLG_HOME_VISIT_DEFAULT { get; set; }
        public string HOMEVISIT_CONTACTNAME { get; set; }
        public string STATE_CODE { get; set; }

        public virtual CM_S_STATE_EXT_AUS CM_S_STATE_EXT_AUS { get; set; }
        public virtual CU_B_ADDRESS CU_B_ADDRESS { get; set; }
    }
}
