using Fox.Microservices.Customers.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models
{
    public class AddressExtended: Address
    {
        [JsonProperty(Order = 1)]
        public string StateDescription { get; set; }

        public AddressExtended()
        {

        }

        public AddressExtended(CU_B_ADDRESS Entity) : base(Entity)
        {
            try
            {
                //This cause EF doesn't support FK on multiple nullable fields
                StateDescription = StateCode;
                //StateDescription = Entity.CU_B_ADDRESS_EXT_AUS?.CM_S_STATE_EXT_AUS?.STATE_NAME;
            }
            catch (Exception)
            {

            }
        }
    }
}
