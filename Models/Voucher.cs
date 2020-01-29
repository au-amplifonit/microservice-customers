using Fox.Microservices.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models
{
    public class Voucher: VoucherBase
    {
        public string TypeDescription { get; set; }
        //public string StatusDescription { get; set; }

        public Voucher()
        {

        }

        public Voucher(CU_B_VOUCHER_EXT_AUS Entity): base(Entity)
        {
            switch(Entity.TYPE_CODE)
            {
                case "R":
                    TypeDescription = "Return";
                    break;
                default:
                    TypeDescription = "New";
                    break;
            }
        }
        /*
        public void LoadDescriptions(CustomersContext AContext)
        {
            StatusDescription = AContext.SY_GENERAL_STATUS.FirstOrDefault(E => E.STATUS_CODE == StatusCode && E.ENTITY_TYPE_CODE == "IS")?.STATUS_DESCR;
        }
        */
    }
}
