using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_VOUCHER_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string VOUCHER_ID { get; set; }
        public string TYPE_CODE { get; set; }
        public DateTime? ISSUE_DATE { get; set; }
        public DateTime? EXPIRY_DATE { get; set; }
        public string DVA_EXEMPT { get; set; }
        public DateTime? MAINTENANCE_EXPIRY_DATE { get; set; }
        public DateTime? LAST_FIT_DATE_LEFT { get; set; }
        public DateTime? LAST_FIT_DATE_RIGHT { get; set; }
        public DateTime? CLIENT_REVIEW_DATE { get; set; }
        public DateTime? LAST_REHAB_DATE { get; set; }
        public string IS_RELOCATED { get; set; }
        public DateTime? FILE_RECEIVED_DATE { get; set; }
        public string PROVIDER_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public DateTime? FILE_REQUESTED_DATE { get; set; }
        public string IS_LAST_ASSESSMENT { get; set; }
        public string STATUS_CODE { get; set; }
        public string COMMON_VOUCHER_ID { get; set; }

        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
    }
}
