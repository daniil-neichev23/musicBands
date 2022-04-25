using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicBands.Core;
using MusicBands.Core.Data;
using MusicBands.DAL.Repositories;
using MusicBands.Services.Transfer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicBands.Services
{
    public class ExportGeneric 
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly DataFactory _dataFactory;

        public ExportGeneric(DataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public void DataSerialization(string name, string pages, string quantity, IConfigurationRoot root)
        {
            //var listOfEntities = DataFactory.GetDataFromDb(name, root);
            var listOfEntities = _dataFactory.GetDataFromDb(name, root);
            string json = JsonConvert.SerializeObject(Pagination.Paging(listOfEntities.ToList(), pages, quantity));

            _log.Info("Serialization completed");
            WriteIntoFile(json, name, root);
        }

        public void WriteIntoFile(string jsonData,string name, IConfigurationRoot root)
        {
            File.WriteAllText(root[(string.Format("FilePaths:{0}", name))], jsonData);
            _log.Info("Json file Generated! check this in your D: folder");
            Console.WriteLine("Json file Generated! check this in your D: folder");
        }
    }
}
