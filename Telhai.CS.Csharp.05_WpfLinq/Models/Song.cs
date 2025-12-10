using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.Csharp._05_WpfLinq.Models
{
    class Song
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }

        public override string ToString()
        {
            return $"{Artist} - {Title} ({Duration:F2} min)";
        }
    }   
}
