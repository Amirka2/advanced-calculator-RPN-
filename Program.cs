using System;
using System.IO;

namespace advanced_calculator__RPN_
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = GetInput();
            Console.WriteLine(input);
            Console.ReadKey();
        }
        static string GetInput()
        {
            string path = "input.txt";
            string input = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    input += line;
                }
            }
            return input;
        }
    }
}
