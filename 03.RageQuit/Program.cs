using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = Console.ReadLine().ToUpper();

            string pattern = @"([^0-9]+)(\d+)";

            Regex patt = new Regex(pattern);

            var result = patt.Matches(inputData);
            string outputData = "";

            var uniqueSymbols = new List<char>();

            StringBuilder text1 = new StringBuilder();

            foreach (Match match in result)
            {
                string text = match.Groups[1].Value;
                int repeat = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeat; i++)
                {
                    text1.Append(text);
                }
                if(repeat != 0) uniqueSymbols.AddRange(text);
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Distinct().Count()}");
            Console.WriteLine(text1);
        }
    }
}
