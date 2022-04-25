using Microsoft.Extensions.Configuration;
using MusicBands.Core.UsableStrings;
using MusicBands.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrands
{
    public static class WorkingWithReports
    {
        public static void ReportsMaking(IConfigurationRoot configurationRoot)
        {
            Reports reports = new Reports(configurationRoot);

            Console.WriteLine(Messages.Result);
            string res = Console.ReadLine();
            if (res.Equals(Commands.Yes))
            {
                Console.Write(Messages.ElementById);
                int number = Int32.Parse(Console.ReadLine());
                if (number <= 0) throw new ArgumentOutOfRangeException("You have to enter valid Id");
                reports.GetElementById(number, configurationRoot);
                Console.Write(Messages.ArtistId);
                int numb = Int32.Parse(Console.ReadLine());
                if (numb <= 0) throw new ArgumentOutOfRangeException("You have to enter valid Id");
                reports.CountSongs(numb, configurationRoot);
                reports.OddSum(configurationRoot);
            }
            else if (res.Equals(Commands.No)) { Console.WriteLine(Messages.GoOn); }
        }
        
    
    
    }
       
}
