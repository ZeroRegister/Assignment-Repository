//数组已经定义好了，没有做数组的输入
using System;
namespace ArrayCalculate
{
    class ArrayCalculate
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 6, 8, 10 };

            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;

            foreach (int number in numbers)
            {
                // 计算最大值
                if (number > max)
                {
                    max = number;
                }
                // 计算最小值
                if (number < min)
                {
                    min = number;
                }
                // 计算所有元素之和
                sum += number;
            }

            // 计算平均值
            double average = (double)sum / numbers.Length;

            Console.WriteLine("最大值：{0}", max);
            Console.WriteLine("最小值：{0}", min);
            Console.WriteLine("平均值：{0:F2}", average);
            Console.WriteLine("所有元素之和：{0}", sum);
            Console.ReadKey();
        }
    }
}
