using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Data
{
    public class Label:Entity
    {
        public int Id { get; set; }
        public int GId { get; set; }
        public string Name { get; set; }
        public string Sort_Name { get; set; }
        public int Type { get; set; }
        public char[] Label_Code { get; set; }
        public int Area { get; set; }   
        public int Begin_Date_Year { get; set; }
        public int Begin_Date_Month { get; set; }
        public int Begin_Date_Day { get; set; }
        public int End_Date_Year { get; set; }
        public int End_Date_Month { get; set; }
        public int End_Date_Day { get; set; }
        public bool Ended { get; set; }
        public string Comment { get; set; }
        public bool Edits_Pending { get; set; }
        public DateTime Last_Updated { get; set; }
    }
}
