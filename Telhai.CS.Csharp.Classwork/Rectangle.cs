namespace Telhai.CS.Csharp.ClassWork;

public class Rectangle: Drawing
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle()
    {
        Height = 5.3;
        Width = 3.4;
    }

    public override double Area()
    {
        return Width * Height;
    }

    public override string ToString()
    {
        return $"Rectangle Id: {Id} Area: {Area()}, Width: {Width}, Height: {Height}";
    }
}