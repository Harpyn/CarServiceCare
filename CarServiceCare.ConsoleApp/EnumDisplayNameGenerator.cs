using CarServiceCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCare.ConsoleApp
{
    public static class EnumDisplayNameGenerator
    {
        public static void GetAllEnumsWithNames<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                System.Console.WriteLine(string.Format($"[Display(Name = \"{item}\")]"));
                System.Console.WriteLine(string.Format($"{item},"));
            }

        }
    }
}
