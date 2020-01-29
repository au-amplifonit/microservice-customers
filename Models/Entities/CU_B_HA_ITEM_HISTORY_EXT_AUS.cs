using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_HA_ITEM_HISTORY_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string IS_LOST { get; set; }
        public string IS_DBR { get; set; }
        public string TYPE_CODE { get; set; }
        public string MAINTENANCE_PLAN_ID { get; set; }
        public DateTime? FITTING_DATE { get; set; }
        public DateTime? WRITEOFF_DATE { get; set; }
        public string WRITEOFF_REASON { get; set; }
        public string ADDITIONAL_NOTES { get; set; }
        public DateTime? SHELLREMAKE_DATE { get; set; }
        public string IS_WRITE_OFF { get; set; }
        public string VOUCHER_NUMBER { get; set; }
        public string BATTERY_SIZE_CODE { get; set; }
        public string SERIAL_NUMBER_VC { get; set; }
        public string DM_SIDE_CODE { get; set; }

        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual CU_S_CUSTOMER_TYPE_EXT_AUS CU_S_CUSTOMER_TYPE_EXT_AUS { get; set; }
        public virtual PD_S_PRODUCT PD_S_PRODUCT { get; set; }
    }
}
