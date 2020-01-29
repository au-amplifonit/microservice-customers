using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_S_CITY_BOOK
    {
        public CM_S_CITY_BOOK()
        {
            CU_B_ADDRESS = new HashSet<CU_B_ADDRESS>();
        }

        public string COUNTRY_CODE { get; set; }
        public string AREA_CODE { get; set; }
        public string ZIP_CODE { get; set; }
        public short CITY_COUNTER { get; set; }
        public string CITY_NAME { get; set; }
        public string ZIP_CODE_UNIQUE_ID { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CM_S_AREA_BOOK CM_S_AREA_BOOK { get; set; }
        public virtual ICollection<CU_B_ADDRESS> CU_B_ADDRESS { get; set; }
    }
}
