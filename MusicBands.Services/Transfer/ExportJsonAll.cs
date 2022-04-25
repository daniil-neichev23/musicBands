//using Microsoft.Extensions.Configuration;
//using MusicBands.Core;
//using MusicBands.Core.Data;
//using MusicBands.DAL.Repositories;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace MusicBands.Services.Transfer
//{
//    public class ExportJsonAll
//    {
//        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        private readonly ExportGeneric _exportGeneric;

//        public ExportJsonAll(ExportGeneric exportGeneric)
//        {
//            _exportGeneric = exportGeneric;
//        }
//        public static void WriteToFile(string name, IConfigurationRoot root)
//        {
//            var p = DataFactory.GetRepository<Area>(name, root);
//            ExportGeneric<Area>.DoStuff(, root);
//            var list = Repository<DataRepositoryArea>.GetData();
//            var list1 = dataRepositoryArtist.GetData();
//            var list2 = dataRepositoryRecording.GetData();
//            var list3 = dataRepositoryLabel.GetData();
//            var list4 = dataRepositoryPlace.GetData();
//            var list5 = dataRepositoryArtistCredit.GetData();
//            var list6 = dataRepositoryArtistCreditName.GetData();

//            string jsonArea = JsonSerializer.Serialize(list);
//            string jsonArtist = JsonSerializer.Serialize(list1);
//            string jsonRecording = JsonSerializer.Serialize(list2);
//            string jsonLabel = JsonSerializer.Serialize(list3);
//            string jsonPlace = JsonSerializer.Serialize(list4);
//            string jsonArtistCredit = JsonSerializer.Serialize(list5);
//            string jsonArtistCreditName = JsonSerializer.Serialize(list6);

//            _log.Info("Serialization completed");

//            File.WriteAllText(root["FilePaths:Area"], jsonArea);
//            File.WriteAllText(root["FilePaths:Artist"], jsonArtist);
//            File.WriteAllText(root["FilePaths:Recording"], jsonRecording);
//            File.WriteAllText(root["FilePaths:Label"], jsonLabel);
//            File.WriteAllText(root["FilePaths:Place"], jsonPlace);
//            File.WriteAllText(root["FilePaths:ArtistCredit"], jsonArtistCredit);
//            File.WriteAllText(root["FilePaths:ArtistCreditName"], jsonArtistCreditName);

//            _log.Info("Json files are generated! Check this via your D: folder");
//            Console.WriteLine("Json files are generated! Check this via your D: folder");
//        }
//    }
//}
