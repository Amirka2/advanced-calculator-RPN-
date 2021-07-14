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
            // making array with input elements 
            while (input.Contains("  ")) { input = input.Replace("  ", " "); }
            input = input.Trim();
            string[] inputArray = input.Split(' ');

            var result = Calculate(inputArray[0], inputArray[1], inputArray[2]);

            Console.WriteLine("result = " + result);
            WriteResult(result);
        }
        static string GetInput()
        {
            string path = "input.txt";
            string input = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    input += line;
                }
                else
                {
                    Console.WriteLine("Пустой ввод");
                    return "Ошибка";
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
        static double Calculate(string x, string op, string y)
        {
            double x1 = Convert.ToDouble(x);
            double x2 = Convert.ToDouble(y);
            double result;
            if (op == "+") result = x1 + x2;
            else if (op == "-") result = x1 - x2;
            else if (op == "*") result = x1 * x2;
            else if (op == "/") result = x1 / x2;
            else
            {
                Console.WriteLine("некорректная операция");
                result = 0;
            }
            return result;
        }
        static void WriteResult(double result)
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(result);
            }
        }
    }
}
