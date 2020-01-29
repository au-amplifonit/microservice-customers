using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Models;

namespace Fox.Microservices.Customers.Models.Audiograms
{
    public class AudiogramBase: ModelBase
    {
        [JsonProperty(Order = -10)]
        public string CustomerID { get; set; }

        [JsonProperty(Order = -10)]
        public DateTime ActivityDate { get; set; }

        [JsonProperty(Order = -10)]
        public short AudiogramTypeCode { get; set; }

        [JsonProperty(Order = -10)]
        public short AudiogramTypeOutCode { get; set; }

        [JsonProperty(Order = -10)]
        public string SideCode { get; set; }

        [JsonProperty(Order = -10)]
        public DateTime DateUpdated { get; set; }

        [JsonProperty(Order = -10)]
        public DateTime DateInserted { get; set; }


        public AudiogramBase()
        {

        }

        public AudiogramBase(CU_B_AUDIOGRAM Entity): base(Entity.ROWGUID)
        {
            CustomerID = Entity.CUSTOMER_CODE;
            ActivityDate = Entity.ACTIVITY_DATE;
            AudiogramTypeCode = Entity.TYPE_CODE;
            AudiogramTypeOutCode = Entity.TYPE_OUT_CODE;
            SideCode = Entity.SIDE_CODE;
            DateInserted = Entity.DT_INSERT.GetValueOrDefault();
            DateUpdated = Entity.DT_UPDATE.GetValueOrDefault(); 
        }

    }

}
