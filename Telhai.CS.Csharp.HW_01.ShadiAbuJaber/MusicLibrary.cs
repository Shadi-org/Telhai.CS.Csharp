namespace Telhai.CS.Csharp.HW_01.ShadiAbuJaber;

using System.Collections.Generic;

public class MusicLibrary
{
    public List<Playlist> Playlists { get; } = new();

    // List to store all songs available in the library
    private List<Song> Songs { get; } = new();

    public void AddPlaylist(Playlist p) => Playlists.Add(p);

    public Playlist? GetPlaylist(int id) => Playlists.Find(p => p.Id == id);

    public void RemovePlaylist(int id) => Playlists.RemoveAll(p => p.Id == id);

    public List<string> GetPlaylistNames()
    {
        List<string> names = new();
        foreach (var p in Playlists)
            names.Add(p.Name);
        return names;
    }

    public void AddSong(Song s) => Songs.Add(s);

    public Song? GetSong(int id) => Songs.Find(s => s.Id == id);

    // Search for song across all playlists
    public Song? FindSongInPlaylists(int id)
    {
        foreach (var p in Playlists)
        {
            var s = p.FindSong(id);
            if (s != null) return s;
        }

        return null;
    }
}