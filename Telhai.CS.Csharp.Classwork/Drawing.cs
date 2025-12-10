namespace Telhai.CS.Csharp.ClassWork;

public class Drawing
{
    private static int _counter = 1;
    protected int Id { get; }

    protected Drawing()
    {
        Id = _counter++;
    }
    public virtual double Area()
    {
        return 0;
    }
}