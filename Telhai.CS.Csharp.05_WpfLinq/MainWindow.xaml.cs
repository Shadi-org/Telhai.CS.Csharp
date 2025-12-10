// Shadi Abu Jaber
// 212955108

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Telhai.CS.Csharp._05_WpfLinq.Models;
using Telhai.CS.Csharp._05_WpfLinq.Services;

namespace Telhai.CS.Csharp._05_WpfLinq;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Store all songs and filtered songs
    private List<Song> _songs = new List<Song>();
    private List<Song> _filteredSongs = new List<Song>();
    
    // Track sort direction for duration and title buttons
    private bool _sortDurationAscending = true;
    private bool _sortTitleAscending = true;
    
    // Get the singleton instance of the service
    private ISongsService _songService = RandomSongService.Instance;

    public MainWindow()
    {
        InitializeComponent();
    }

    // Update title when user selects a song
    private void songsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (songsListBox.SelectedItem is Song song)
        {
            this.Title = $"Selected: {song.Artist} - {song.Title}";
        }
    }

    // Load 50 random songs from the service
    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        _songs = _songService.GenerateSongs(50);
        _filteredSongs = new List<Song>(_songs);
        RefreshDisplay();
        lblStatus.Content = "Loaded 50 songs";
    }

    // Delete selected song from list and data
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (songsListBox.SelectedItem is Song song)
        {
            _songs.Remove(song);
            _filteredSongs.Remove(song);
            RefreshDisplay();
            lblStatus.Content = $"Deleted: {song.Title}";
        }
        else
        {
            MessageBox.Show("Please select a song to delete", "Delete Song", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // Add new song with validation
    private void btnAddSong_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateAddSongInputs(out string artist, out string title, out double duration))
            return;

        Song newSong = new Song
        {
            Id = Guid.NewGuid(),
            Artist = artist,
            Title = title,
            Duration = duration
        };

        _songs.Add(newSong);
        _filteredSongs = new List<Song>(_songs);
        ClearAddSongInputs();
        RefreshDisplay();
        lblStatus.Content = $"Added: {title}";
    }

    // Check if inputs are valid before adding song
    private bool ValidateAddSongInputs(out string artist, out string title, out double duration)
    {
        artist = txtArtist.Text.Trim();
        title = txtTitle.Text.Trim();
        duration = 0;

        // Check if artist and title are not empty
        if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(title))
        {
            MessageBox.Show("Artist and Title cannot be empty", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        // Check if duration is a valid number between 2 and 10
        if (!double.TryParse(txtDuration.Text, out duration) || duration < 2.0 || duration > 10.0)
        {
            MessageBox.Show("Duration must be a number between 2.0 and 10.0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }

    // Clear all textboxes
    private void ClearAddSongInputs()
    {
        txtArtist.Clear();
        txtTitle.Clear();
        txtDuration.Clear();
    }

    // Sort by duration - toggle between ascending and descending
    private void btnSortDuration_Click(object sender, RoutedEventArgs e)
    {
        if (_filteredSongs.Count == 0)
            return;

        if (_sortDurationAscending)
        {
            _filteredSongs = _filteredSongs.OrderBy(s => s.Duration).ToList();
        }
        else
        {
            _filteredSongs = _filteredSongs.OrderByDescending(s => s.Duration).ToList();
        }

        _sortDurationAscending = !_sortDurationAscending;
        RefreshDisplay();
        lblStatus.Content = $"Sorted by Duration ({(_sortDurationAscending ? "Descending next" : "Ascending next")})";
    }

    // Sort by title - toggle between ascending and descending
    private void btnSortTitle_Click(object sender, RoutedEventArgs e)
    {
        if (_filteredSongs.Count == 0)
            return;

        if (_sortTitleAscending)
        {
            _filteredSongs = _filteredSongs.OrderBy(s => s.Title).ToList();
        }
        else
        {
            _filteredSongs = _filteredSongs.OrderByDescending(s => s.Title).ToList();
        }

        _sortTitleAscending = !_sortTitleAscending;
        RefreshDisplay();
        lblStatus.Content = $"Sorted by Title ({(_sortTitleAscending ? "Descending next" : "Ascending next")})";
    }

    // Search songs by artist or title (case insensitive)
    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
        string searchText = txtSearch.Text.Trim().ToLower();

        // If search is empty, show all songs sorted by title
        if (string.IsNullOrEmpty(searchText))
        {
            _filteredSongs = _songs.OrderBy(s => s.Title).ToList();
        }
        else
        {
            _filteredSongs = _songs
                .Where(s => s.Artist.ToLower().Contains(searchText) || s.Title.ToLower().Contains(searchText))
                .ToList();
        }

        RefreshDisplay();
        lblStatus.Content = $"Found {_filteredSongs.Count} songs";
    }

    // Show only short songs (less than 3 minutes)
    private void btnShortHits_Click(object sender, RoutedEventArgs e)
    {
        _filteredSongs = _songs
            .Where(s => s.Duration < 3)
            .OrderBy(s => s.Title)
            .ToList();

        RefreshDisplay();
        lblStatus.Content = $"Found {_filteredSongs.Count} songs shorter than 0.3 minutes";
    }

    // Group songs by artist and show count
    private void btnGroupByArtist_Click(object sender, RoutedEventArgs e)
    {
        if (_songs.Count == 0)
        {
            MessageBox.Show("No songs to group", "Group by Artist", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        // Group songs by artist name
        var groupedSongs = _songs
            .GroupBy(s => s.Artist)
            .OrderBy(g => g.Key)
            .ToList();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Songs Grouped by Artist:\n");

        foreach (var group in groupedSongs)
        {
            sb.AppendLine($"{group.Key}: {group.Count()} songs");
        }

        MessageBox.Show(sb.ToString(), "Group by Artist", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // Update listbox with filtered songs
    private void RefreshDisplay()
    {
        songsListBox.Items.Clear();
        foreach (Song song in _filteredSongs)
        {
            songsListBox.Items.Add(song);
        }

        UpdateStatistics();
    }

    // Calculate and display statistics (total, average, longest)
    private void UpdateStatistics()
    {
        if (_filteredSongs.Count == 0)
        {
            lblTotalDuration.Content = "0.00 min";
            lblAvgLength.Content = "0.00 min";
            lblLongestSong.Content = "N/A";
            return;
        }

        // Calculate sum, average, and find longest song
        double totalDuration = _filteredSongs.Sum(s => s.Duration);
        double avgLength = _filteredSongs.Average(s => s.Duration);
        Song longestSong = _filteredSongs.OrderByDescending(s => s.Duration).First();

        lblTotalDuration.Content = $"{totalDuration:F2} min";
        lblAvgLength.Content = $"{avgLength:F2} min";
        lblLongestSong.Content = longestSong.Title;
    }
}