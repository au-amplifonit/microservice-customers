using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Customers.Helpers
{
    public static class StringHelper
    {
        public static string Join(string[] Items)
        {
            string Result = string.Join("\n", Items.Where(E => !string.IsNullOrWhiteSpace(E)));
            return Result;
        }

        public static string Join(string Item1, string Item2, string Item3 = null, string Item4 = null)
        {
            string[] Items = new string[] { Item1, Item2, Item3, Item4 };
            return Join(Items);
        }

        public static string[] Split(string Items)
        {
            string[] Result = Items.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            return Result;
        }

        public static void Split(string Items, out string Item1, out string Item2, out string Item3, out string Item4)
        {
            string[] Result = Split(Items);
            Item1 = Result.Length > 0 ? Result[0] : null;
            Item2 = Result.Length > 1 ? Result[1] : null;
            Item3 = Result.Length > 2 ? Result[2] : null;
            Item4 = Result.Length > 3 ? Result[3] : null;
        }
    }
}
