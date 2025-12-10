using System;
using System.Collections.Generic;
using Telhai.CS.Csharp._05_WpfLinq.Models;

namespace Telhai.CS.Csharp._05_WpfLinq.Services
{
    // Singleton service to generate random songs
    class RandomSongService : ISongsService
    {
        private static RandomSongService _instance;
        private static readonly object _lockObject = new object();
        
        // Lists of artist and song titles for random selection
        private readonly string[] _artists = new string[]
        {
            "Arik Ainstein",
            "David Broza",
            "Omer Adam",
            "Eyal Golan",
            "Mahmood Darwish",
            "Rita",
            "Enrique Iglesias",
            "Rihanna",
            "The Beatles",
            "Ed Sheeran"
        };

        private readonly string[] _titles = new string[]
        {
            "Love Song",
            "Midnight Dreams",
            "Summer Night",
            "Desert Wind",
            "Ocean Waves",
            "City Lights",
            "Dancing Rain",
            "Morning Light",
            "Silent Prayer",
            "Golden Hour"
        };

        // Random generator for picking songs
        private Random _random = new Random();

        private RandomSongService()
        {
        }

        // Thread-safe singleton pattern
        public static RandomSongService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new RandomSongService();
                        }
                    }
                }
                return _instance;
            }
        }

        // Generate random songs with random artist, title, and duration
        public List<Song> GenerateSongs(int count)
        {
            List<Song> songs = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                songs.Add(new Song
                {
                    Id = Guid.NewGuid(),
                    Artist = _artists[_random.Next(_artists.Length)],
                    Title = _titles[_random.Next(_titles.Length)],
                    // Duration: random between 2 and 10 minutes
                    Duration = Math.Round(_random.NextDouble() * 8.0 + 2.0, 2)
                });
            }

            return songs;
        }
    }
}
