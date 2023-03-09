using System;

namespace PrimeNumbers
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            // 创建一个大小为101的数组，用来存储从0到100的数字
            bool[] flags = new bool[101];
            // 除了0和1之外，把所有的标志初始化为真
            for (int i = 2; i < flags.Length; i++)
            {
                flags[i] = true;
            }
            // 从2循环到100的平方根
            for (int i = 2; i * i <= 100; i++)
            {
                // 如果i的标志是真，说明它是一个素数
                if (flags[i])
                {
                    // 从i * i循环到100
                    for (int j = i * i; j <= 100; j += i)
                    {
                        // 把j的标志设为假，说明它是i的倍数
                        flags[j] = false;
                    }
                }
            }
            // 遍历数组，打印出标志为真的数字
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}