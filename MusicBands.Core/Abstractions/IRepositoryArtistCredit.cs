using MusicBands.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Abstractions
{
    public interface IRepositoryArtistCredit : IRepository<ArtistCredit>
    {
        public List<ArtistCredit> GetData();
    }
}
