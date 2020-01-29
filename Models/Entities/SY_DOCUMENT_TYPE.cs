using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class SY_DOCUMENT_TYPE
    {
        public SY_DOCUMENT_TYPE()
        {
            CM_B_ATTACHMENT = new HashSet<CM_B_ATTACHMENT>();
            CM_S_ATTACHMENT_DOCUMENT = new HashSet<CM_S_ATTACHMENT_DOCUMENT>();
            CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPE = new HashSet<CU_B_HA_ITEM_HISTORY>();
            CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPENavigation = new HashSet<CU_B_HA_ITEM_HISTORY>();
            CU_B_NOTE = new HashSet<CU_B_NOTE>();
            SY_ACTIVITY_TYPE = new HashSet<SY_ACTIVITY_TYPE>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public string DOCUMENT_TYPE_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CM_B_ATTACHMENT> CM_B_ATTACHMENT { get; set; }
        public virtual ICollection<CM_S_ATTACHMENT_DOCUMENT> CM_S_ATTACHMENT_DOCUMENT { get; set; }
        public virtual ICollection<CU_B_HA_ITEM_HISTORY> CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPE { get; set; }
        public virtual ICollection<CU_B_HA_ITEM_HISTORY> CU_B_HA_ITEM_HISTORYSY_DOCUMENT_TYPENavigation { get; set; }
        public virtual ICollection<CU_B_NOTE> CU_B_NOTE { get; set; }
        public virtual ICollection<SY_ACTIVITY_TYPE> SY_ACTIVITY_TYPE { get; set; }
    }
}
