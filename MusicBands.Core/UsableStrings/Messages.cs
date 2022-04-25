using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.UsableStrings
{
    public static class Messages
    {
        public static string Enter { get; } = "Please Enter name of the file: ";
        public static string Ids { get; } = "What should we do when face existing Ids? (enter either Merge or Skip)";
        public static string Result { get; } = "Do you need result of reports?";
        public static string ElementById { get; } = "Please Enter Id to get elements: ";
        public static string ArtistId { get; } = "Please Enter Id of artist to count his songs: ";
        public static string GoOn { get; } = "Move on!";
        public static string Page { get; } = "Enter page number: ";
        public static string Quantity { get; } = "Enter quantity of items per page: ";
        public static string Table { get; } = "Enter name for the table: ";
        public static string Crash { get; } = "Crash!";
        public static string BadCredentials { get; } = "You entered the wrong name of the table!";
        public static string Check { get; } = "Please enter the correct table name (Area, Artist, ArtistCredit, " +
                        "ArtistCreditName, Label, Place, Recording";
    }
}
