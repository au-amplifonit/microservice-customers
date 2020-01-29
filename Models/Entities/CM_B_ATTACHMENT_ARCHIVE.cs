using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CM_B_ATTACHMENT_ARCHIVE
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SHOP_CODE { get; set; }
        public long ATTACHMENT_COUNTER { get; set; }
        public byte[] ATTACHMENT { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
    }
}
