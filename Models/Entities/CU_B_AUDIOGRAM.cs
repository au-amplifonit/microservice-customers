using System;
using System.Collections.Generic;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_AUDIOGRAM
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public DateTime ACTIVITY_DATE { get; set; }
        public short TYPE_CODE { get; set; }
        public short TYPE_OUT_CODE { get; set; }
        public short HICONDITION_CODE { get; set; }
        public string SIDE_CODE { get; set; }
        public short FRAME { get; set; }
        public string MATERIAL { get; set; }
        public int? FREQ_1 { get; set; }
        public double? VALUE_1 { get; set; }
        public string FLGMASK_1 { get; set; }
        public string FLGNOANSWER_1 { get; set; }
        public int? FREQ_2 { get; set; }
        public double? VALUE_2 { get; set; }
        public string FLGMASK_2 { get; set; }
        public string FLGNOANSWER_2 { get; set; }
        public int? FREQ_3 { get; set; }
        public double? VALUE_3 { get; set; }
        public string FLGMASK_3 { get; set; }
        public string FLGNOANSWER_3 { get; set; }
        public int? FREQ_4 { get; set; }
        public double? VALUE_4 { get; set; }
        public string FLGMASK_4 { get; set; }
        public string FLGNOANSWER_4 { get; set; }
        public int? FREQ_5 { get; set; }
        public double? VALUE_5 { get; set; }
        public string FLGMASK_5 { get; set; }
        public string FLGNOANSWER_5 { get; set; }
        public int? FREQ_6 { get; set; }
        public double? VALUE_6 { get; set; }
        public string FLGMASK_6 { get; set; }
        public string FLGNOANSWER_6 { get; set; }
        public int? FREQ_7 { get; set; }
        public double? VALUE_7 { get; set; }
        public string FLGMASK_7 { get; set; }
        public string FLGNOANSWER_7 { get; set; }
        public int? FREQ_8 { get; set; }
        public double? VALUE_8 { get; set; }
        public string FLGMASK_8 { get; set; }
        public string FLGNOANSWER_8 { get; set; }
        public int? FREQ_9 { get; set; }
        public double? VALUE_9 { get; set; }
        public string FLGMASK_9 { get; set; }
        public string FLGNOANSWER_9 { get; set; }
        public int? FREQ_10 { get; set; }
        public double? VALUE_10 { get; set; }
        public string FLGMASK_10 { get; set; }
        public string FLGNOANSWER_10 { get; set; }
        public int? FREQ_11 { get; set; }
        public double? VALUE_11 { get; set; }
        public string FLGMASK_11 { get; set; }
        public string FLGNOANSWER_11 { get; set; }
        public int? FREQ_12 { get; set; }
        public double? VALUE_12 { get; set; }
        public string FLGMASK_12 { get; set; }
        public string FLGNOANSWER_12 { get; set; }
        public int? FREQ_13 { get; set; }
        public double? VALUE_13 { get; set; }
        public string FLGMASK_13 { get; set; }
        public string FLGNOANSWER_13 { get; set; }
        public int? FREQ_14 { get; set; }
        public double? VALUE_14 { get; set; }
        public string FLGMASK_14 { get; set; }
        public string FLGNOANSWER_14 { get; set; }
        public int? FREQ_15 { get; set; }
        public double? VALUE_15 { get; set; }
        public string FLGMASK_15 { get; set; }
        public string FLGNOANSWER_15 { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CU_B_ADDRESS_BOOK CU_B_ADDRESS_BOOK { get; set; }
        public virtual CU_S_AUDIOGRAM_TYPE CU_S_AUDIOGRAM_TYPE { get; set; }
        public virtual SY_SIDE SY_SIDE { get; set; }
    }
}
