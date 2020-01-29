using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_S_ATTACHMENT_TYPE
    {
        public CM_S_ATTACHMENT_TYPE()
        {
            CM_B_ATTACHMENT = new HashSet<CM_B_ATTACHMENT>();
            CM_S_ATTACHMENT_DOCUMENT = new HashSet<CM_S_ATTACHMENT_DOCUMENT>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string ATTACHMENT_TYPE_CODE { get; set; }
        public string ATTACHMENT_TYPE_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CM_B_ATTACHMENT> CM_B_ATTACHMENT { get; set; }
        public virtual ICollection<CM_S_ATTACHMENT_DOCUMENT> CM_S_ATTACHMENT_DOCUMENT { get; set; }
    }
}
