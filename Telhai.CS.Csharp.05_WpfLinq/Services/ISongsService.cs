using Telhai.CS.Csharp._05_WpfLinq.Models;

namespace Telhai.CS.Csharp._05_WpfLinq.Services
{
    interface ISongsService
    {
        List<Song> GenerateSongs(int count);
    }
}
