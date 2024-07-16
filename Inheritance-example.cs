// Base class
public abstract class Shape
{
    public string Color { get; set; }
    public (int X, int Y) Position { get; set; }

    public Shape(string color, int x, int y)
    {
        Color = color;
        Position = (x, y);
    }

    public abstract void Draw();
    public abstract void Resize(int newWidth, int newHeight);
}

// Derived class Circle
public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle(string color, int x, int y, int radius)
        : base(color, x, y)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} circle at ({Position.X}, {Position.Y}) with radius {Radius}");
    }

    public override void Resize(int newRadius, int _)
    {
        Radius = newRadius;
        Console.WriteLine($"Resized the circle to new radius {Radius}");
    }
}

// Derived class Rectangle
public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(string color, int x, int y, int width, int height)
        : base(color, x, y)
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {Color} rectangle at ({Position.X}, {Position.Y}) with width {Width} and height {Height}");
    }

    public override void Resize(int newWidth, int newHeight)
    {
        Width = newWidth;
        Height = newHeight;
        Console.WriteLine($"Resized the rectangle to new width {Width} and height {Height}");
    }
}

// Usage
class Program
{
    static void Main()
    {
        Circle circle = new Circle("Red", 10, 10, 15);
        circle.Draw();  // Output: Drawing a Red circle at (10, 10) with radius 15
        circle.Resize(20, 0);  // Output: Resized the circle to new radius 20

        Rectangle rectangle = new Rectangle("Blue", 5, 5, 30, 40);
        rectangle.Draw();  // Output: Drawing a Blue rectangle at (5, 5) with width 30 and height 40
        rectangle.Resize(35, 45);  // Output: Resized the rectangle to new width 35 and height 45
    }
}