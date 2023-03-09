using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            double num1, num2, result;
            char op;

            Console.WriteLine("Enter the first number: ");//输入第一个数据
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");//输入第二个数据
            num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operator (+, -, *, /): ");//输入运算符
            op = Convert.ToChar(Console.ReadLine());

            switch (op)//进行运算
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine("Result: " + result);
                    break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine("Result: " + result);
                    break;
                case '*':
                    result = num1 * num2;
                    Console.WriteLine("Result: " + result);
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine("Result: " + result);
                    }
                    else
                    {
                        Console.WriteLine("Error: division by zero");
                    }
                    break;
                default:
                    Console.WriteLine("Error: invalid operator");
                    break;
            }

            Console.ReadKey();
        }
    }
}