using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models.DTO
{
    public class MyMusician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual MyMusician MyMusician { get; set; }
        public virtual MyTrack MyTrack { get; set; }

    }
}
