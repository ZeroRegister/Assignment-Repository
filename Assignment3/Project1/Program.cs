//编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
using System;
namespace PolymorphismApplication
{
    //抽象类Shape，含有一个抽象方法area()用于计算面积，抽象方法不用给出结构体
    abstract class Shape
    {
        abstract public double Area();
        abstract public void IsRight();
    }
    //抽象类的继承，分别有Rectangle,Square,Triangle这三个类继承了Shape类
    class Rectangle : Shape
    {
        double length;
        double width;
        public Rectangle(double a = 0, double b = 0)
        {
            length = a; 
            width = b;
        }
    //每个派生类中都有对于area()方法的重载
        public override double Area()
        {
            Console.WriteLine("计算Rectangle类的面积");
            return length * width;
        }
    //每个派生类中独有对于IsRight()方法的重载
        public override void IsRight()
        {
            if(length <=0 || width <= 0)
            {
                Console.WriteLine("Rectangle类的实例不合法");
            }
            else
            {
                Console.WriteLine("Rectangle类的实例合法");
            }
        }
    }

    class Square : Shape
    {
        double length;
        public Square(double a = 0) 
        {
            length = a;
        }

        public override double Area()
        {
            Console.WriteLine("计算Square类的面积");
            return length * length;
        }
        public override void IsRight()
        {
            if (length <= 0)
            {
                Console.WriteLine("Square类的实例不合法");
            }
            else
                Console.WriteLine("Square类的实例合法");
        }
    }

    class Triangle : Shape
    {
        //三角形使用简化的底和高来表示某一个三角形（可能不是特别严谨）
        double length;
        double height;
        public Triangle(double a, double b)
        {
            length = a;
            height = b;
        }
        public override double Area()
        {
            Console.WriteLine("计算Triangle类的面积");
            return (length * height)/2;//为什么(length * height)*(1/2)的结果会变成0？？？
        }
        public override void IsRight()
        {
            if (length <= 0 || height <= 0)
            {
                Console.WriteLine("Triangle类的实例不合法");
            }
            else
                Console.WriteLine("Triangle类的实例合法");
        }
    }
    //遵循单一功能原则，再写一个Caller调用类，使用这个类的对象来调用上述三个类
    class Caller
    {
        public void CallArea(Shape shape)
        {
            Console.WriteLine("面积为：{0}", shape.Area());
        }
        public void CallIsRigth(Shape shape)
        {
            shape.IsRight();
        }
    }

    class ShapeTester
    {
        static void Main(string[] args)
        {
            Caller c = new Caller();
            Rectangle r = new Rectangle(2.0,3.0);
            Square s = new Square(2.0);
            Triangle t = new Triangle(2.0,3.0);
            //调用,先调用IsRigth()方法，再调用Area()方法
            c.CallIsRigth(r);
            c.CallArea(r);
            Console.WriteLine();
            c.CallIsRigth(s);
            c.CallArea(s);
            Console.WriteLine();
            c.CallIsRigth(t);
            c.CallArea(t);
            Console.ReadKey();
        }
    }
}