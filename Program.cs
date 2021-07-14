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
        static readonly double fStep = 1;
        static readonly double fStart = -2;
        static readonly double fEnd = 5;
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
            else if ((!IsDigit(array[0])) | (!IsVariable(array[0]))) return false;
            else if ((!IsDigit(array[2])) | (!IsVariable(array[2]))) return false;
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
        static bool IsVariable(string x)
        {
            if (x == "x") return true;
            else return false;
        }
        static double Calculate(string X1, string op, string X2)  //переделать лоигку под работу с переменными
        {
            double x1, x2;
            if (IsVariable(X1)) x1 = fStart;
            else x1 = Convert.ToDouble(X1);
            if (IsVariable(X2)) x2 = fStart;
            else x2 = Convert.ToDouble(X2);
            double y;
            for (double i = fStart; i <= fEnd; i += fStep)
            {
                if (op == "+") y = x1 + x2;
                else if (op == "-") y = x1 - x2;
                else if (op == "*") y = x1 * x2;
                else if (op == "/") y = x1 / x2;
                else
                {
                    Console.WriteLine("некорректная операция");
                    y = 0;
                }
            }
            return y;
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
