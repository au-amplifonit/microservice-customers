using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Audiograms
{
    public class AudiogramExtended: Audiogram
    {
        [JsonProperty(Order = 1)]
        public string AudiogramTypeDescription { get; set; }

        [JsonProperty(Order = 1)]
        public string SideDescription { get; set; }

        [JsonProperty(Order = 1)]
        public string AudiogramTypeOutDescription { get; set; }

        [JsonProperty(Order = 1)]
        public string HiConditionDescription { get; set; }

        public AudiogramExtended()
        {

        }

        public AudiogramExtended(CU_B_AUDIOGRAM Entity) : base(Entity)
        {
            AudiogramTypeDescription = Entity.CU_S_AUDIOGRAM_TYPE?.AUDIOGRAM_TYPE_DESCR;
            SideDescription = Entity.SY_SIDE?.SIDE_DESCR;
        }

        public void LoadDescriptions(CustomersContext AContext)
        {
            AudiogramTypeOutDescription = AContext.CU_S_AUDIOGRAM_TYPE.FirstOrDefault(E => E.AUDIOGRAM_TYPE_CODE == AudiogramTypeOutCode)?.AUDIOGRAM_TYPE_DESCR;
            HiConditionDescription = AContext.CU_S_HICONDITION.FirstOrDefault(E => E.HICONDITION_CODE == HiConditionCode)?.HICONDITION_DESCR;
        }
    }
}
