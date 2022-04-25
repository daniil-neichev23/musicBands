using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Data
{
    public class ArtistCreditName:Entity
    {
        public int Artist_Credit { get; set; }
        public string Position { get; set; }
        public int Artist { get; set; }
        public string Name { get; set; }
        public string Join_Phrase { get; set; }
    }
}
