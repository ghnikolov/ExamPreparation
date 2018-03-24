using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftuniCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOrders = int.Parse(Console.ReadLine());

            decimal totalPrice = 0m;

            for (int i = 0; i < countOrders; i++)
            {
                var priceCoffee = decimal.Parse(Console.ReadLine());
                var dataTime = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var countCapsules = long.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(dataTime.Year, dataTime.Month);

                var monthPriceCoffee = (daysInMonth * countCapsules) * priceCoffee;

                Console.WriteLine($"The price for the coffee is: ${monthPriceCoffee:F2}");
                totalPrice += monthPriceCoffee;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
         }
    }
}
