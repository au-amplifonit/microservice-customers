using Fox.Microservices.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Audiograms
{
    public class AudiogramListItem : AudiogramBase
    {
        public string AudiogramTypeDescription { get; set; }
        public string SideDescription { get; set; }
        public string AudiogramTypeOutDescription { get; set; }


        public AudiogramListItem()
        {

        }

        public AudiogramListItem(CU_B_AUDIOGRAM Entity) : base(Entity)
        {
            AudiogramTypeDescription = Entity.CU_S_AUDIOGRAM_TYPE?.AUDIOGRAM_TYPE_DESCR;
            SideDescription = Entity.SY_SIDE?.SIDE_DESCR;
        }

        public void LoadDescriptions(CustomersContext AContext)
        {
            AudiogramTypeOutDescription = AContext.CU_S_AUDIOGRAM_TYPE.FirstOrDefault(E => E.AUDIOGRAM_TYPE_CODE == AudiogramTypeOutCode)?.AUDIOGRAM_TYPE_DESCR;
        }

    }
}
