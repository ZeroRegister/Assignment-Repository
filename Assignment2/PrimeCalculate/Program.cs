using System; 
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("请输入一个正整数：");
        int num = int.Parse(Console.ReadLine()); // 从控制台读取一行输入，并转换为整数
        Console.WriteLine("该数的所有素数因子如下："); 
        List<int> factors = GetPrimeFactors(num);
        for (int i = 0; i < factors.Count; i++) // 使用for循环遍历列表中的每个元素，i是索引变量
        {
            int factor = factors[i]; 
            Console.Write(factor + " "); // 输出每个素数因子
        }
    }

    static List<int> GetPrimeFactors(int num) 
    {
        List<int> factors = new List<int>(); // 创建一个空的整数列表，用于存储素数因子
        for (int i = 2; i <= num; i++) // 从2开始循环，直到等于num为止
        {
            while (num % i == 0) // 如果num能被i整除，则说明i是num的一个素数
            {
                factors.Add(i); // 将i添加到列表中
                num /= i; // 将num除以i，并赋值给num，继续寻找下一个素数
            }
        }
        return factors; // 返回列表
    }
}