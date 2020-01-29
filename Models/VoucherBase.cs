using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models
{
    public class VoucherBase: ModelBase
    {
        [JsonProperty(Order = -10)]
        public string CustomerCode { get; set; }
        [JsonProperty(Order = -10)]
        public string VoucherID { get; set; }
        [JsonProperty(Order = -10)]
        public string TypeCode { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? IssueDate { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? ExpirationDate { get; set; }
        [JsonProperty(Order = -10)]
        public bool DVAExempt { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? MaintenanceExpirationDate { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? LastFitDateLeft { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? LastFitDateRight { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? ClientReviewDate { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? LastRehabDate { get; set; }
        [JsonProperty(Order = -10)]
        public bool IsRelocated { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? FileRecevicedDate { get; set; }
        [JsonProperty(Order = -10)]
        public string ProviderCode { get; set; }
        [JsonProperty(Order = -10)]
        public DateTime? FileRequestedDate { get; set; }
        [JsonProperty(Order = -10)]
        public bool IsLastAssessment { get; set; }
        [JsonProperty(Order = -10)]
        public string StatusCode { get; set; }
        [JsonProperty(Order = -10)]
        public string CommonVoucherID { get; set; }

        public VoucherBase()
        {

        }

        public VoucherBase(CU_B_VOUCHER_EXT_AUS Entity):base(Entity.ROWGUID)
        {
            CustomerCode = Entity.CUSTOMER_CODE;
            VoucherID = Entity.VOUCHER_ID;
            TypeCode = Entity.TYPE_CODE;
            IssueDate = Entity.ISSUE_DATE;
            ExpirationDate = Entity.EXPIRY_DATE;
            DVAExempt = Entity.DVA_EXEMPT == "Y";
            MaintenanceExpirationDate = Entity.MAINTENANCE_EXPIRY_DATE;
            LastFitDateLeft = Entity.LAST_FIT_DATE_LEFT;
            LastFitDateRight = Entity.LAST_FIT_DATE_RIGHT;
            ClientReviewDate = Entity.CLIENT_REVIEW_DATE;
            LastRehabDate = Entity.LAST_REHAB_DATE;
            IsRelocated = Entity.IS_RELOCATED == "Y";
            FileRecevicedDate = Entity.FILE_RECEIVED_DATE;
            ProviderCode = Entity.PROVIDER_CODE;
            FileRequestedDate = Entity.FILE_REQUESTED_DATE;
            IsLastAssessment = Entity.IS_LAST_ASSESSMENT == "Y";
            StatusCode = Entity.STATUS_CODE;
            CommonVoucherID = Entity.COMMON_VOUCHER_ID;
        }
    }
}
