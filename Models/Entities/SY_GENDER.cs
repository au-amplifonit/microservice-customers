using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class SY_GENDER
    {
        public SY_GENDER()
        {
            CU_B_ADDRESS_BOOK = new HashSet<CU_B_ADDRESS_BOOK>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string GENDER_CODE { get; set; }
        public string GENDER_DESCR { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CU_B_ADDRESS_BOOK> CU_B_ADDRESS_BOOK { get; set; }
    }
}
