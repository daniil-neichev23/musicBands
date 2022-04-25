using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Data
{
    public class ArtistCredit : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Artist_Count { get; set; }
        public int Ref_Count { get; set; }
        public bool Created { get; set; }
    }
}
