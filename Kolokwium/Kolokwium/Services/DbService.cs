using Kolokwium.Models;
using Kolokwium.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MyAlbum>> getAlbum(int idAlbum)
        {
            var album = await _dbContext.Albums.Where(a => a.IdAlbum == idAlbum).Select(a => new MyAlbum
            {
                IdAlbum = a.IdAlbum,
                AlbumName = a.AlbumName,
                PublishDate = a.PublishDate,
                MyTracks = a.MyTracks
                .Select(t => new MyTrack
                {
                    IdTrack = t.IdTrack,
                    TrackName = t.TrackName,
                    Duration = t.Duration,
                    IdMusicAlbum = t.IdMusicAlbum
                }).ToList()
            }).ToListAsync();

            return album;
        }
    }
}
