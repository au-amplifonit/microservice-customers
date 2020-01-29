using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_S_ATTACHMENT_DOCUMENT
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string ATTACHMENT_TYPE_CODE { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public string MARKET_TYPE_CODE { get; set; }
        public string FLG_MANDATORY { get; set; }
        public string FLG_NOTE { get; set; }
        public DateTime? FLG_DATE { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CM_S_ATTACHMENT_TYPE CM_S_ATTACHMENT_TYPE { get; set; }
        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPE { get; set; }
    }
}
