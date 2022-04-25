using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Data
{
    public class Recording:Entity
    {
        public int Id { get; set; }
        public int GId { get; set; }
        public string Name { get; set; }
        public int Artist_Credit { get; set; }
        public int Length { get; set; }
        public string Comment { get; set; }
        public bool Edits_Pending { get; set; }
        public DateTime Last_Updated { get; set; }
    }
}
