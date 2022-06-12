using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models.DTO
{
    public class MyTrack
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
        public virtual MyAlbum MyAlbum {set;get;}
        public virtual ICollection<MyMusician_Track> MyMusicianTracks { get; set; }
    }
}
