namespace Telhai.CS.Csharp.ClassWork;

public class Square:Drawing
{
    public double Length { get; set; }
    public Square()
    {
        Length = 6;
    }

    public override double Area()
    {
        return Math.Pow(Length, 2);
    }
    
    public override string ToString()
    {
        return $"Square Id: {Id} Area: {Area()}, Length: {Length}";
    }
    
}