using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_B_ATTACHMENT
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SHOP_CODE { get; set; }
        public long ATTACHMENT_COUNTER { get; set; }
        public Guid REASON_ID { get; set; }
        public DateTime? ATTACHMENT_DATE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string ATTACHMENT_TYPE_CODE { get; set; }
        public string ATTACHMENT_NAME { get; set; }
        public DateTime? DT_EXPIRATION { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public string DOCUMENT_NUMBER { get; set; }
        public DateTime? DOCUMENT_DATE { get; set; }
        public string VERSION { get; set; }
        public string REASON_CODE { get; set; }
        public string NOTE { get; set; }
        public string STATUS_CODE { get; set; }
        public DateTime? DT_UPDATE_STATUS { get; set; }
        public string VALIDATION_STATUS_CODE { get; set; }
        public DateTime? DT_UPDATE_VALIDATION_STATUS { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CM_B_SHOP CM_B_SHOP { get; set; }
        public virtual CM_S_ATTACHMENT_TYPE CM_S_ATTACHMENT_TYPE { get; set; }
        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPE { get; set; }
    }
}
