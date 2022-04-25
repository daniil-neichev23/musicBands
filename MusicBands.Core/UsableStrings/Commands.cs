using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.UsableStrings
{
    public static class Commands
    {
        public const string Area = "Area";
        public const string Artist = "Artist";
        public const string ArtistCredit = "ArtistCredit";
        public const string ArtistCreditName = "ArtistCreditName";
        public const string Label = "Label";
        public const string Place = "Place";
        public const string Recording = "Recording";
        public const string All = "All";
        public const string Yes = "Yes";
        public const string No  = "No";
        public const string Merge  = "Merge";
        public const string Skip  = "Skip";
        
        public static bool GetAllProperties(string tableName)
        {
            List<string> propertyList = new List<string>()
            {
                Area,Artist,ArtistCredit,ArtistCreditName,Label,Place,Recording, All
            };

            return propertyList.Contains(tableName);
        }
    }
}
