using System;

//定义一个抽象类Shape，表示形状
abstract class Shape
{
    //定义一个抽象方法GetArea，用于计算面积
    public abstract double GetArea();
}

//定义一个类Circle，表示圆形，继承自Shape
class Circle : Shape
{
    //定义一个字段radius，表示半径
    private double radius;

    //定义一个构造函数，接受半径作为参数，并赋值给radius字段
    public Circle(double radius)
    {
        this.radius = radius;
    }

    //重写GetArea方法，返回圆形的面积
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

//定义一个类Square，表示正方形，继承自Shape
class Square : Shape
{
    //定义一个字段side，表示边长
    private double side;

    //定义一个构造函数，接受边长作为参数，并赋值给side字段
    public Square(double side)
    {
        this.side = side;
    }

    //重写GetArea方法，返回正方形的面积
    public override double GetArea()
    {
        return side * side;
    }
}

//定义一个类Rectangle，表示矩形，继承自Shape
class Rectangle : Shape
{//定义两个字段length和width，表示长度和宽度
    private double length;
    private double width;

    //定义一个构造函数，接受长度和宽度作为参数，并赋值给length和width字段
    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    //重写GetArea方法，返回矩形的面积 
    public override double GetArea()
    {
        return length * width;
    }
}

//定义一个类Triangle, 表示三角形, 继承自Shape 
class Triangle : Shape
{
    // 定义三个字段a,b,c, 表示三条边长 
    private double a;
    private double b;
    private double c;

    // 定义一个构造函数, 接受三条边长作为参数, 并赋值给a,b,c字段 
    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // 重写GetArea方法, 返回三角形的面积 (使用海伦公式)  
    public override double GetArea()
    {
        double p = (a + b + c) / 2;  // 计算半周长  
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));  // 计算并返回面积  
    }

}

// 定义一个类ShapeFactory, 表示简单工厂类  
class ShapeFactory
{
    // 定义一个静态方法CreateShape, 接受字符串类型作为参数  
    public static Shape CreateShape(string type)
    {
        Shape shape = null;  // 定义一个变量shape, 初始化为null  

        switch (type)  // 根据type参数选择创建不同类型的对象  
        {
            case "Circle":  //
                shape = new Circle(10);  // 创建一个半径为10的圆形对象并赋值给shape变量
                break;
            case "Square":
                shape = new Square(5);  // 创建一个边长为5的正方形对象并赋值给shape变量
                break;
            case "Rectangle":
                shape = new Rectangle(8, 6);  // 创建一个长度为8，宽度为6的矩形对象并赋值给shape变量
                break;
            case "Triangle":
                shape = new Triangle(3, 4, 5);  // 创建一个三条边分别为3，4，5的三角形对象并赋值给shape变量
                break;
            default:
                Console.WriteLine("参数无效");  // 如果type参数无效，则输出错误信息
                break;
        }

        return shape;  // 返回shape变量
    }

}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();  // 创建一个随机数生成器对象

        string[] types = { "Circle", "Square", "Rectangle", "Triangle" };  // 定义一个字符串数组，存储四种形状类型

        Shape[] shapes = new Shape[10];  // 定义一个Shape数组，用于存储10个形状对象

        for (int i = 0; i < 10; i++)  // 循环10次
        {
            int index = random.Next(0, 4);  // 随机生成0到3之间的整数作为索引

            string type = types[index];  // 根据索引从types数组中取出对应的类型

            shapes[i] = ShapeFactory.CreateShape(type);  // 调用简单工厂类的CreateShape方法根据类型创建对应的对象，并存入shapes数组中

            Console.WriteLine("第{0}个形状是一个{1}, 它的面积是：{2}", i + 1, type, shapes[i].GetArea()); //输出每个对象的序号、类型和面积
        }

        double sum = 0;  // 定义一个变量sum，用于存储面积之和

        foreach (Shape shape in shapes)  // 遍历shapes数组中的每个对象
        {
            sum += shape.GetArea();  // 调用每个对象的GetArea方法并累加到sum变量中
        }

        Console.WriteLine("面积之和为：{0}", sum);  // 输出面积之和

    }
}