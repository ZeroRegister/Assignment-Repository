using System;

class Program
{
    static void Main(string[] args)
    {
        bool[] isPrime = new bool[101];
        for (int i = 2; i <= 100; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i <= 100; i++)
        {
            if (isPrime[i])
            {
                for (int j = 2 * i; j <= 100; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        Console.WriteLine("2 ~ 100 以内的素数有：");
        for (int i = 2; i <= 100; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }
}