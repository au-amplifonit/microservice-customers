using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Entities
{
    public partial class CU_B_ADDRESS_BOOK
    {
        public CU_B_ADDRESS MainAddress
        {
            get { return CU_B_ADDRESS.FirstOrDefault(E => E.ADDRESS_COUNTER == 1); }
        }
    }
}
