using log4net;
using Microsoft.Extensions.Configuration;
using MusicBands.Core.Data;
using MusicBands.Core.UsableStrings;
using MusicBands.DAL;
using System;
using System.Reflection;

namespace MusicBrands
{
    public static class MakingImport
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void ImportingJson(string tableName, IConfigurationRoot iconfiguration, string procedureName)
        {
            DapperImportJson dapper = new DapperImportJson(iconfiguration);

            if (!Commands.GetAllProperties(tableName))
            {
                Console.WriteLine(Messages.BadCredentials);
            }

            try
            {
                switch (tableName)
                {
                    case Commands.Area:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<Area>(procedureName, tableName);
                        break;
                    case Commands.Artist:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<Artist>(procedureName, tableName);
                        break;
                    case Commands.ArtistCredit:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<ArtistCredit>(procedureName, tableName);
                        break;
                    case Commands.ArtistCreditName:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<ArtistCreditName>(procedureName, tableName);
                        break;
                    case Commands.Label:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<Label>(procedureName, tableName);
                        break;
                    case Commands.Place:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<Place>(procedureName, tableName);
                        break;
                    case Commands.Recording:
                        Console.WriteLine(Messages.Ids);
                        procedureName = Console.ReadLine();
                        dapper.ImportJson<Recording>(procedureName, tableName);
                        break;
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Messages.Crash);
                log.Error("ArgumentException was caused");
            }
        }
    }
}
