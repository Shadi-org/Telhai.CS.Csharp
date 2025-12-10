namespace Telhai.CS.Csharp.HW_01.ShadiAbuJaber;

using System;
using System.Collections.Generic;

public class Playlist
{
    private static int _counter = 1;

    public int Id { get; }
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
                throw new Exception("Playlist name must have at least 3 characters");
            _name = value;
        }
    }

    public List<Song> Songs { get; }

    public Playlist()
    {
        Id = _counter++;
        Songs = new List<Song>();
    }

    public Playlist(string name) : this() => Name = name;

    public Playlist(string name, List<Song> songs) : this(name) => Songs = songs;

    public void Print()
    {
        Console.WriteLine(ToString());
        foreach (var song in Songs)
            Console.WriteLine("  " + song);
    }

    public override string ToString()
    {
        return $"Playlist Id: {Id}, Name: {Name}, Total Songs: {Songs.Count}";
    }

    /// <summary>
    /// Add song to playlist
    /// </summary>
    /// <param name="s"></param>
    public void AddSong(Song s) => Songs.Add(s);

    /// <summary>
    /// Remove song from playlist by its ID
    /// </summary>
    /// <param name="songId"></param>
    public void RemoveSong(int songId) => Songs.RemoveAll(s => s.Id == songId);

    /// <summary>
    /// Find song in playlist by its ID
    /// </summary>
    /// <param name="songId"></param>
    /// <returns></returns>
    public Song? FindSong(int songId) => Songs.Find(s => s.Id == songId);

    /// <summary>
    /// Get total duration of all songs in the playlist
    /// </summary>
    /// <returns></returns>
    public double GetTotalDuration()
    {
        double total = 0;
        foreach (var s in Songs)
            total += s.Duration;
        return total;
    }
}