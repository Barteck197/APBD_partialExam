using Kolokwium.Models;
using Kolokwium.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDbService
    {
        Task<IEnumerable<MyAlbum>> getAlbum(int idAlbum);
    }
}
