namespace Telhai.CS.Csharp.ClassWork;

class Program
{
    static void Main(string[] args)
    {
        string userName = Environment.UserName;
        string machineName = Environment.MachineName;
        string osVersion = Environment.OSVersion.ToString();

        Console.WriteLine("User Name: " + userName);
        Console.WriteLine("Machine Name: " + machineName);
        Console.WriteLine("Operating System: " + osVersion);
        Console.WriteLine("---------------------");

        Drawing square = new Square();
        Drawing rectangle = new Rectangle();

        List<Drawing> drawings = new List<Drawing>();
        drawings.Add(square);
        drawings.Add(rectangle);
        foreach (var drawing in drawings)
        {
            Console.WriteLine($"Area: {drawing.Area()}");
        }

        Dictionary<string, Drawing> drawingDict = new Dictionary<string, Drawing>();
        drawingDict["MySquare"] = square;
        drawingDict["MyRectangle"] = rectangle;
        foreach (var key in drawingDict.Keys)
        {
            Console.WriteLine($"{key} Area: {drawingDict[key].Area()}");
        }

        foreach (var d in drawings)
        {
            Console.WriteLine(d.ToString());
        }
    }
}