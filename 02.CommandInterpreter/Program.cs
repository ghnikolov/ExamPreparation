using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end") break;

                string[] comand = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (comand[0])
                {
                    case "reverse":
                        {
                            array = Reverse(array, int.Parse(comand[2]), int.Parse(comand[4]));
                        } break;
                    case "sort":
                        {
                            array = Sort(array, int.Parse(comand[2]), int.Parse(comand[4]));
                        }
                        break;
                    case "rollLeft":
                        {
                            array = RollLeft(array, int.Parse(comand[1]));
                        }
                        break;
                    case "rollRight":
                        {
                            array = RollRight(array, int.Parse(comand[1]));
                        }
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static string[] Reverse(string[] array, int start, int count)
        {
            if (start < 0 || start >= array.Length || count < 0 || count + start < 0 || count - 1 + start >= array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            var firstPart = array.Take(start).ToArray();
            var middlePart = array.Skip(start).Take(count).Reverse().ToArray();
            var endPart = array.Skip(start + count).ToArray();

            array = firstPart.Concat(middlePart).Concat(endPart).ToArray();
            return array;
        }

        static string[] Sort(string[] array, int start, int count)
        {

            if (start < 0 || start >= array.Length || count < 0 || count + start < 0 || count - 1 + start >= array.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            var firstPart = array.Take(start).ToArray();
            var middlePart = array.Skip(start).Take(count).OrderBy(g => g).ToArray();
            var endPart = array.Skip(start + count).ToArray();

            array = firstPart.Concat(middlePart).Concat(endPart).ToArray();
            return array;
        }
        static string[] RollLeft(string[] array, int count)
        {
            if ( count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            count = count % array.Length;
            var firstPart = array.Skip(count).ToArray();
            var endPart = array.Take(count).ToArray();

            array = firstPart.Concat(endPart).ToArray();
            return array;
        }
        static string[] RollRight(string[] array, int count)
        {
            if (count < 0 )
            {
                Console.WriteLine("Invalid input parameters.");
                return array;
            }

            count = count % array.Length;
            var firstPart = array.Skip(array.Length - count).ToArray();
            var endPart = array.Take(array.Length - count).ToArray();

            array = firstPart.Concat(endPart).ToArray();
            return array;
        }
    }
}
