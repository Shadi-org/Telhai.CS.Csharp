namespace Telhai.CS.Csharp.HW_01.ShadiAbuJaber;

using System;

class Program
{
    static void Main()
    {
        var library = new MusicLibrary();

        try
        {
            var song1 = new Song("Imagine", "John Lennon", 1971, 3.1, Genre.Rock);
            var song2 = new Song { Title = "Billie Jean", Artist = "Michael Jackson", Year = 1982, Duration = 4.54, Genre = Genre.Pop };
            var song3 = new Song("Hey Jude", "The Beatles", 1968, 7.11, Genre.Rock);
            library.AddSong(song1);
            library.AddSong(song2);
            library.AddSong(song3);

            var p1 = new Playlist("Chill");
            p1.AddSong(song1);
            p1.AddSong(song2);
            library.AddPlaylist(p1);

            var p2 = new Playlist("Top Hits");
            p2.AddSong(song3);
            library.AddPlaylist(p2);
        }
        catch (Exception e)
        {
            Console.WriteLine("Initialization error: " + e.Message);
        }

        var menu = new ConsoleMenu(library);
        menu.Run();
    }
}