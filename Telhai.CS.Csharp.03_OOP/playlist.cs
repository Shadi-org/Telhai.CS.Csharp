using Telhai.CS.Csharp.Services.Logging;
namespace Telhai.CS.Csharp._03_OOP;

public class Playlist
{

    private List<string> songs;
    private string name;

    // Empty Ctor
    public Playlist() : this("NO NAME")
    {

        Logger.LogStatic("In Empty Ctor", LogLevel.Debug);
    }

    public Playlist(string name)
    {
        Name = name;// calling set
        songs = new List<string>();

    }

    public string Name
    {
        get { return name.ToUpper(); }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                name = "<NO PLATLIST NAME>";

            }
            name = value;
        }
    }

    

    /// <summary>
    /// auto properties
    /// </summary>
    public int Id
    {
        get;
        set;
    }

    public int Count
    {
        // get { return songs.Count; }
        get => songs.Count;
    }

    // shorter way
    // public int Count => songs.Count;


}

