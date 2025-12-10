namespace Telhai.CS.Csharp.HW_01.ShadiAbuJaber;

using System;

public class ConsoleMenu
{
    private readonly MusicLibrary _library;
    private bool _running = true;

    public ConsoleMenu(MusicLibrary library)
    {
        _library = library;
    }

    public void Run()
    {
        while (_running)
        {
            PrintMenu();
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": CreatePlaylist(); break;
                case "2": CreateSong(); break;
                case "3": AddSongToPlaylist(); break;
                case "4": ShowSongsInPlaylist(); break;
                case "5": RemoveSongFromPlaylistById(); break;
                case "6": ShowAllPlaylists(); break;
                case "7": ShowSongsInPlaylistByGenre(); break;
                case "8": RemovePlaylistById(); break;
                case "0":
                    _running = false;
                    Console.WriteLine("Goodbye.");
                    break;
                default: Console.WriteLine("Unknown option. Please choose a valid number."); break;
            }

            Console.WriteLine();
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("=== Music Library Menu - By Shadi Abu Jaber  212955108 ===");
        Console.WriteLine(".1 Create new playlist");
        Console.WriteLine(".2 Create new song");
        Console.WriteLine(".3 Add existing song to playlist");
        Console.WriteLine(".4 Show all songs in a playlist");
        Console.WriteLine(".5 Remove song from playlist by ID");
        Console.WriteLine(".6 Show all playlists");
        Console.WriteLine(".7 Show songs in a playlist by genre");
        Console.WriteLine(".8 Remove playlist by ID");
        Console.WriteLine(".0 Exit\n");
    }

    private void CreatePlaylist()
    {
        Console.Write("Enter playlist name: ");
        var name = Console.ReadLine();
        try
        {
            var p = new Playlist { Name = name };
            _library.AddPlaylist(p);
            Console.WriteLine($"Playlist '{p.Name}' created with ID {p.Id}.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to create playlist: " + e.Message);
        }
    }

    private void CreateSong()
    {
        Console.Write("Enter song title: ");
        var title = Console.ReadLine();
        Console.Write("Enter artist: ");
        var artist = Console.ReadLine();
        Console.Write("Enter year: ");
        var yearInput = Console.ReadLine();
        Console.Write("Enter duration: ");
        var durInput = Console.ReadLine();
        Console.WriteLine("Choose genre: 0=Pop,1=Rock,2=Jazz,3=Classical,4=HipHop,5=Electronic,6=Other");
        Console.Write("Enter Genre number: ");
        var genreInput = Console.ReadLine();

        try
        {
            var year = int.Parse(yearInput ?? "0");
            var dur = double.Parse(durInput ?? "0");
            var g = int.Parse(genreInput ?? "6");
            var song = new Song(title ?? string.Empty, artist ?? string.Empty, year, dur, (Genre)g);
            _library.AddSong(song);
            Console.WriteLine($"Song '{song.Title}' by {song.Artist} created with ID {song.Id}.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to create song: " + e.Message);
        }
    }

    private void AddSongToPlaylist()
    {
        Console.Write("Enter playlist ID: ");
        var plInput = Console.ReadLine();
        if (!int.TryParse(plInput, out var pid))
        {
            Console.WriteLine("Invalid playlist ID.");
            return;
        }

        var playlist = _library.GetPlaylist(pid);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found.");
            return;
        }

        Console.Write("Enter song ID: ");
        var sInput = Console.ReadLine();
        if (!int.TryParse(sInput, out var sid))
        {
            Console.WriteLine("Invalid song ID.");
            return;
        }

        // Search in central song list first, then in playlists
        var song = _library.GetSong(sid) ?? _library.FindSongInPlaylists(sid);
        if (song == null)
        {
            Console.WriteLine("Song not found.");
            return;
        }

        playlist.AddSong(song);
        Console.WriteLine("The song was added successfully.");

        Console.WriteLine($"Song {song.Title} added to playlist '{playlist.Name}'.");
    }

    private void ShowSongsInPlaylist()
    {
        Console.Write("Enter playlist ID: ");
        var plInput = Console.ReadLine();
        if (!int.TryParse(plInput, out var pid))
        {
            Console.WriteLine("Invalid playlist ID.");
            return;
        }

        var playlist = _library.GetPlaylist(pid);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found.");
            return;
        }

        Console.WriteLine($"Songs in playlist '{playlist.Name}':");
        foreach (var s in playlist.Songs)
            Console.WriteLine(s);
    }

    private void RemoveSongFromPlaylistById()
    {
        Console.Write("Enter playlist ID: ");
        var plInput = Console.ReadLine();
        if (!int.TryParse(plInput, out var pid))
        {
            Console.WriteLine("Invalid playlist ID.");
            return;
        }

        var playlist = _library.GetPlaylist(pid);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found.");
            return;
        }

        Console.Write("Enter song ID to remove: ");
        var sInput = Console.ReadLine();
        if (!int.TryParse(sInput, out var sid))
        {
            Console.WriteLine("Invalid song ID.");
            return;
        }

        var exists = playlist.FindSong(sid);
        if (exists == null)
        {
            Console.WriteLine("Song not found in playlist.");
            return;
        }

        playlist.RemoveSong(sid);
        Console.WriteLine("Song removed from playlist.");
    }

    private void ShowAllPlaylists()
    {
        Console.WriteLine("Playlists in library:");
        foreach (var p in _library.Playlists)
            p.Print();
    }

    private void ShowSongsInPlaylistByGenre()
    {
        Console.Write("Enter playlist ID: ");
        var plInput = Console.ReadLine();
        if (!int.TryParse(plInput, out var pid))
        {
            Console.WriteLine("Invalid playlist ID.");
            return;
        }

        var playlist = _library.GetPlaylist(pid);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found.");
            return;
        }

        Console.WriteLine("Choose genre number: 0=Pop,1=Rock,2=Jazz,3=Classical,4=HipHop,5=Electronic,6=Other");
        Console.Write("Genre number: ");
        var gInput = Console.ReadLine();
        if (!int.TryParse(gInput, out var g))
        {
            Console.WriteLine("Invalid genre number.");
            return;
        }

        Console.WriteLine($"Songs in playlist '{playlist.Name}' with genre {(Genre)g}:");
        foreach (var s in playlist.Songs)
            if (s.Genre == (Genre)g)
                Console.WriteLine(s);
    }

    private void RemovePlaylistById()
    {
        Console.Write("Enter playlist ID to remove: ");
        var plInput = Console.ReadLine();
        if (!int.TryParse(plInput, out var pid))
        {
            Console.WriteLine("Invalid playlist ID.");
            return;
        }

        var exists = _library.GetPlaylist(pid);
        if (exists == null)
        {
            Console.WriteLine("Playlist not found.");
            return;
        }

        _library.RemovePlaylist(pid);
        Console.WriteLine("Playlist removed.");
    }
}