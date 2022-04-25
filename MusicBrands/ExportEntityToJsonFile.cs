using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicBands.Core.UsableStrings;
using MusicBands.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrands
{
    public class ExportEntityToJsonFile
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ExportGeneric _exportGeneric;
        public ExportEntityToJsonFile(ExportGeneric exportGeneric)
        {
            _exportGeneric = exportGeneric;
        }
        public void ExportJson(string tableName,string pages, string quantity, IConfigurationRoot root)
        {
            ContinueWork(out tableName, out pages, out quantity);
            while (true)
            {
                    try
                    {
                    if (tableName == Commands.All)
                    {
                        _exportGeneric.DataSerialization(Commands.Area, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.Artist, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.ArtistCredit, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.ArtistCreditName, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.Label, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.Place, pages, quantity, root);
                        _exportGeneric.DataSerialization(Commands.Recording, pages, quantity, root);
                    }
                    else
                    {
                        _exportGeneric.DataSerialization(tableName, pages, quantity, root);
                    }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine(Messages.Crash);
                        log.Error("ArgumentOutOfRangeException was caused");
                    }
                    ContinueWork(out tableName, out quantity, out pages);
            }
        }
        public static void ContinueWork(out string tableName, out string pages, out string quantity)
        {
            Console.Write(Messages.Table);
            tableName = Console.ReadLine();

            if (!Commands.GetAllProperties(tableName))
            {
                Console.WriteLine(Messages.Check);
                ContinueWork(out tableName, out pages, out quantity);
            }
            else if (tableName == Commands.All)
            {
                quantity = string.Empty;
                pages = string.Empty;
            }
            else
            {
                Console.Write(Messages.Page);
                pages = Console.ReadLine();
                Console.Write(Messages.Quantity);
                quantity = Console.ReadLine();
            }

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}
