namespace Telhai.CS.Csharp._03_OOP;

public class Program
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


        Playlist l1 = new Playlist();
        Type type = l1.GetType();
        type.ToString();

        l1.Name = "Chill_Out"; // set
        var namePlaylist = l1.Name; // get
        l1.Name += "Playlist"; // get then set

        int count = l1.Count;

        Playlist l2 = new Playlist();
        l2.Name = "TECHNO";
        l2.Id = 12345;

        Playlist l3 = new Playlist("AMBIENT");

        // Initializer - calling empty Ctor
        Playlist l4 = new Playlist { Id = 1001, Name = "LOAZI" };


        Console.ReadKey();
    }
}