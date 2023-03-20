using System;
using System.Collections.Generic;

class Node<T>
{
    public T value;
    public Node<T> next;
}

class LinkedList<T>
{
    public Node<T> head;

    // 添加ForEach方法
    public void ForEach(Action<T> action)
    {
        // 遍历链表节点，执行action操作
        Node<T> current = head;
        while (current != null)
        {
            action(current.value);
            current = current.next;
        }
    }
}

class Program
{
    static void Main()
    {
        // 创建一个泛型链表实例
        LinkedList<int> list = new LinkedList<int>();
        list.head = new Node<int>() { value = 10 };
        list.head.next = new Node<int>() { value = 20 };
        list.head.next.next = new Node<int>() { value = 30 };

        // 打印链表元素
        Console.WriteLine("The linked list values:");
        list.ForEach(x => Console.WriteLine(x));

        // 求最大值、最小值和求和
        int max = int.MinValue;
        int min = int.MaxValue;
        int sum = 0;

        list.ForEach(x =>
        {
            if (x > max) max = x; // 更新最大值
            if (x < min) min = x; // 更新最小值
            sum += x; // 累加求和
        });

        Console.WriteLine("The maximum value is: {0}", max);
        Console.WriteLine("The minimum value is: {0}", min);
        Console.WriteLine("The sum is: {0}", sum);
    }
}