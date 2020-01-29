using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_NOTE
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int NOTE_COUNTER { get; set; }
        public DateTime NOTE_DATE { get; set; }
        public string SHOP_CODE { get; set; }
        public string FLG_RESERVED { get; set; }
        public string ACTIVITY_TYPE_CODE { get; set; }
        public string APPOINTMENT_ID { get; set; }
        public string SUBJECT { get; set; }
        public string NOTE { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public DateTime? DOCUMENT_DATE { get; set; }
        public string DOCUMENT_NUMBER { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public DateTime? NOTE_DATETIME { get; set; }

        public virtual CM_B_SHOP CM_B_SHOP { get; set; }
        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual SY_ACTIVITY_TYPE SY_ACTIVITY_TYPE { get; set; }
        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPE { get; set; }
    }
}
