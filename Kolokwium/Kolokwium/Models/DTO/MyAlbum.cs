using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models.DTO
{
    public class MyAlbum
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual ICollection<MyTrack> MyTracks { get; set; }
        public MyMusicLabel MyMusicLabel { get; set; }
    }
}
