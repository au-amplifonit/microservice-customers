using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Helpers
{
	public static class CustomerHelper
	{
		public static int CalculatAge(DateTime birthDate)
		{
			int Result = DateTime.Today.Year - birthDate.Year;

			if (Result > 0)
				Result -= Convert.ToInt32(DateTime.Today.Date < birthDate.Date.AddYears(Result));
			else
				Result = 0;

			return Result;
		}
	}
}
