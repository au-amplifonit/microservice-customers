using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_HA_ITEM_HISTORY
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string SERIAL_NUMBER { get; set; }
        public string SIDE_CODE { get; set; }
        public string DOCUMENT_NUMBER { get; set; }
        public DateTime? DOCUMENT_DATE { get; set; }
        public string DOCUMENT_TYPE_CODE { get; set; }
        public string SUPPORTED_PRODUCT_CODE { get; set; }
        public string SUPPORTED_SERIAL_NUMBER { get; set; }
        public string PURCHASE_NUMBER { get; set; }
        public DateTime? PURCHASE_DATE { get; set; }
        public string ORIGINAL_DOCUMENT_NUMBER { get; set; }
        public DateTime? ORIGINAL_DOCUMENT_DATE { get; set; }
        public string ORIGINAL_DOCUMENT_TYPE_CODE { get; set; }
        public DateTime? PURCHASE_RECEIVING_DATE { get; set; }
        public string MARKET_TYPE_CODE { get; set; }
        public DateTime? DELIVERY_DATE { get; set; }
        public DateTime? WARRANTY_START_DATE { get; set; }
        public DateTime? WARRANTY_END_DATE { get; set; }
        public string EXT_WARRANTY_NUMBER { get; set; }
        public DateTime? EXT_WARRANTY_START_DATE { get; set; }
        public DateTime? EXT_WARRANTY_END_DATE { get; set; }
        public string ORIGINAL_SERIAL_NUMBER { get; set; }
        public string ITEM_STATUS_CODE { get; set; }
        public string COMPETITOR_CODE { get; set; }
        public int? REPAIR_COUNTER { get; set; }
        public DateTime? FUND_END_DATE { get; set; }
        public DateTime? FUND_START_DATE { get; set; }
        public string COVERAGE_TYPE_CODE { get; set; }
        public double? SALE_UNIT_GROSS_PRICE { get; set; }
        public double? SALE_UNIT_NET_PRICE { get; set; }
        public string SALE_PRICELIST_CODE { get; set; }
        public double? TAX_RATE { get; set; }
        public DateTime? DT_STATUS_UPDATE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual PD_S_PRODUCT PD_S_PRODUCT { get; set; }
        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPE { get; set; }
        public virtual SY_DOCUMENT_TYPE SY_DOCUMENT_TYPENavigation { get; set; }
        public virtual SY_SIDE SY_SIDE { get; set; }
    }
}
