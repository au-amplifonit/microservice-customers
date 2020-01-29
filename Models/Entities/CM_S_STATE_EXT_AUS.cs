﻿using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_S_STATE_EXT_AUS
    {
        public CM_S_STATE_EXT_AUS()
        {
            CU_B_ADDRESS_EXT_AUS = new HashSet<CU_B_ADDRESS_EXT_AUS>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string STATE_CODE { get; set; }
        public string STATE_NAME { get; set; }
        public short STATE_COUNTER { get; set; }
        public string DEFAULT_AREA_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_ADDRESS_EXT_AUS> CU_B_ADDRESS_EXT_AUS { get; set; }
    }
}
