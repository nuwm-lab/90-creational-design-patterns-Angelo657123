using System;

// Базовий клас для фігур
abstract class Shape
{
    // Абстрактний метод для виведення координат
    public abstract void DisplayCoefficients();
}

// Клас Rectangle
class Rectangle : Shape
{
    public double B1 { get; set; }
    public double A1 { get; set; }
    public double B2 { get; set; }
    public double A2 { get; set; }

    public void SetCoefficients(double b1, double a1, double b2, double a2)
    {
        B1 = b1;
        A1 = a1;
        B2 = b2;
        A2 = a2;
    }

    public bool ContainsPoint(double x, double y)
    {
        return B1 <= x && x <= A1 && B2 <= y && y <= A2;
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Rectangle bounds: B1={B1}, A1={A1}, B2={B2}, A2={A2}");
    }
}

// Клас Parallelepiped
class Parallelepiped : Rectangle
{
    public double C1 { get; set; }
    public double C2 { get; set; }

    public void SetCoefficients(double b1, double a1, double b2, double a2, double c1, double c2)
    {
        base.SetCoefficients(b1, a1, b2, a2);
        C1 = c1;
        C2 = c2;
    }

    public bool ContainsPoint(double x, double y, double z)
    {
        return base.ContainsPoint(x, y) && C1 <= z && z <= C2;
    }

    public override void DisplayCoefficients()
    {
        base.DisplayCoefficients();
        Console.WriteLine($"C1={C1}, C2={C2}");
    }
}

// Абстрактна фабрика
abstract class ShapeFactory
{
    public abstract Shape CreateShape();
}

// Фабрика для створення Rectangle
class RectangleFactory : ShapeFactory
{
    public override Shape CreateShape()
    {
        return new Rectangle();
    }
}

// Фабрика для створення Parallelepiped
class ParallelepipedFactory : ShapeFactory
{
    public override Shape CreateShape()
    {
        return new Parallelepiped();
    }
}

// Програма
class Program
{
    static void Main()
    {
        // Створення фабрики для Rectangle
        ShapeFactory rectangleFactory = new RectangleFactory();
        Rectangle rect = (Rectangle)rectangleFactory.CreateShape();
        rect.SetCoefficients(1, 5, 2, 6);
        rect.DisplayCoefficients();
        Console.WriteLine($"Point (3,4) in rectangle: {rect.ContainsPoint(3, 4)}");

        // Створення фабрики для Parallelepiped
        ShapeFactory parallelepipedFactory = new ParallelepipedFactory();
        Parallelepiped para = (Parallelepiped)parallelepipedFactory.CreateShape();
        para.SetCoefficients(1, 5, 2, 6, 0, 10);
        para.DisplayCoefficients();
        Console.WriteLine($"Point (3,4,5) in parallelepiped: {para.ContainsPoint(3, 4, 5)}");
    }
}
