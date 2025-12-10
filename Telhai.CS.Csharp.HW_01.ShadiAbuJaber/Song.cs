namespace Telhai.CS.Csharp.HW_01.ShadiAbuJaber;

using System;

public enum Genre
{
    Pop,
    Rock,
    Jazz,
    Classical,
    HipHop,
    Electronic,
    Other
}

public class Song
{
    private static int _counter = 1;

    public int Id { get; }
    private string _title;
    private string _artist;
    private int _year;
    private double _duration;
    private Genre _genre;

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2)
                throw new Exception("Title must be at least 2 characters and not empty");
            _title = value;
        }
    }

    public string Artist
    {
        get => _artist;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Artist is required");
            _artist = value;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1900 || value > 2025)
                throw new Exception("Year must be between 1900 and 2025");
            _year = value;
        }
    }

    public double Duration
    {
        get => _duration;
        set
        {
            if (value <= 0 || value > 20)
                throw new Exception("Duration must be between 0 and 20 minutes");
            _duration = value;
        }
    }

    public Genre Genre
    {
        get => _genre;
        set
        {
            if (!Enum.IsDefined(value))
                throw new ArgumentException("Invalid genre value");

            _genre = value;
        }
    }

    public Song() => Id = _counter++;

    public Song(string title, string artist, int year, double duration, Genre genre) : this()
    {
        Title = title;
        Artist = artist;
        Year = year;
        Duration = duration;
        Genre = genre;
    }

    public void Print()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Year: {Year}, Duration: {Duration} min, Genre: {Genre}";
    }
}