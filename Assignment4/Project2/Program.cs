using System;

// 定义委托
public delegate void AlarmHandler();

// 定义闹钟类
public class Alarm
{
    // 定义事件
    public event AlarmHandler Ring;

    // 定义触发事件的方法
    protected virtual void OnRing()
    {
        if (Ring != null)
        {
            Ring(); // 触发事件
        }
    }

    // 定义设置闹钟时间的方法
    public void SetTime(DateTime alarmTime)
    {
        Console.WriteLine("Alarm set at {0}", alarmTime);
        while (true)
        {
            // 如果当前时间等于闹钟时间，则触发事件
            if (DateTime.Now == alarmTime)
            {
                OnRing();
                break;
            }
        }
    }
}

// 定义人类
public class Person
{
    // 定义处理事件的方法
    public void WakeUp()
    {
        Console.WriteLine("Person wakes up!");
    }
}

// 主程序
class Program
{
    static void Main(string[] args)
    {
        // 创建对象
        Alarm a = new Alarm();
        Person p = new Person();

        // 注册事件
        a.Ring += new AlarmHandler(p.WakeUp);

        // 设置闹钟时间为10秒后
        DateTime alarmTime = DateTime.Now.AddSeconds(10);

        // 调用设置闹钟时间的方法并等待触发事件 
        a.SetTime(alarmTime);

    }
}