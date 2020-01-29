using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Models.Entities
{ 
	public partial class CustomersContext : DbContext
	{
		public DbQuery<LEAD_CUSTOMER> LeadAndCustomers { get; set; }
	}
}
