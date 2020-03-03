using System;
using System.Collections.Generic;
using System.Linq;

namespace String_Calculator_Kata
{
    public class String_Calculator
    {


        private const string CustomDelimeter = "//";
        private static readonly List<string> Delimeters = new List<string>() { ",", "\n" };

        static void Main(string[] args)   //This method is just here to keep it running
        {
            bool running = true;
            while (running)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    running = false;
                }
                else
                {
                    int output = Add(input);
                    // Console.WriteLine(output);    //Not allowed by the rules but the program would be incomplete without it
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.StartsWith(CustomDelimeter))
            {
                numbers = AddCustomDelimeters(numbers);
            }

            List<int> cleaned = SplitNumbers(numbers);
            return cleaned.Sum();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        private static string AddCustomDelimeters(string numbers)
        {
            string[] customDelimeters = { CustomDelimeter, "[", "]" };
            string customDelimeter = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(customDelimeter.Length, numbers.Length - customDelimeter.Length);
            List<string> allCustomDelimiter = customDelimeter.Split(customDelimeter, StringSplitOptions.RemoveEmptyEntries).ToList();
            allCustomDelimiter.ForEach(o => Delimeters.Add(o));
            return numbers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static List<int> SplitNumbers(string numbers)
        {
            List<String> nums = numbers.Split(Delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> cleaned = new List<int>();
            nums.ForEach(o =>
            {
                var cleanedNumber = int.Parse(o);
                if (cleanedNumber < 0)
                {
                    throw new ApplicationException("Number cannot be negative");
                }

                if (cleanedNumber <= 1000)
                {
                    cleaned.Add(cleanedNumber);
                }
            });
            return cleaned;

        }
    }
}
