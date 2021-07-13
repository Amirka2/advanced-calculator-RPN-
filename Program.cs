using System;
using System.IO;

namespace advanced_calculator__RPN_
{
    class Program
    {
        /*enum operators                                            как лучше сделать?
        {
            plus = 0, minus = 1, multiply = 2, divide = 3
        }*/
        static void Main(string[] args)
        {
            string input = GetInput();
            if (!IsInputCorrect(input)) 
            {
                Console.WriteLine("Некорректное выражение!");
                return;                                             /*можно так завершать?*/
            }
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
        static bool IsInputCorrect(string input)
        {
            while (input.Contains("  ")) { input = input.Replace("  ", " "); }
            input = input.Trim();
            string[] array = input.Split(' ');
            if (array.Length != 3) return false;
            else if (!IsDigit(array[0])) return false;
            else if (!IsDigit(array[2])) return false;
            else if (!IsOperation(array[1])) return false;
            else return true;
        }
        static bool IsDigit(string x)
        {
            char[] digits = x.ToCharArray();
            foreach (char ch in digits)
            {
                if ((ch < 48) || (ch > 57)) return false;
            }
            return true;
        }
        static bool IsOperation(string x)
        {
            char[] digits = x.ToCharArray();
            if (digits.Length > 1) return false;
            if ((x == "+") || (x == "-") || (x == "*") || (x == "/")) return true;
            return false;
        }
    }
}
