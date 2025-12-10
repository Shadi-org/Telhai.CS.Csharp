using Telhai.Csharpproject._01Practice.Logger;

namespace Telhai.CS.Csharp._01_practice;

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


        Console.WriteLine("");

        for (int i = 0; i < 10; i++)
        {
            if (i % 5 == 0)
            {
                Logger.log("Running Main " + i + LogLevel.Debug);
                continue;
            }


            Logger.log("Running Main " + i);
        }
    }
}