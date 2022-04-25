using Dapper;
using Microsoft.Extensions.Configuration;
using MusicBands.Core.Data;
using MusicBands.Core.UsableStrings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicBands.DAL
{
    public class DapperImportJson
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DapperImportJson(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }
        
        public void ImportJson<T>(string procedure, string tableName)
        {
            string json = File.ReadAllText(string.Format(@"C:\Users\dneichev\Documents\{0}.json", tableName));
            var areaList = JsonConvert.DeserializeObject<List<T>>(json);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var numberOfAffectedRows = string.Format(procedure,StringComparison.CurrentCultureIgnoreCase) switch
                {
                    Commands.Merge=>connection.Execute(string.Format("{0}InsertMerge", tableName), areaList,
                    commandType: CommandType.StoredProcedure),
                    Commands.Skip=> connection.Execute(string.Format("{0}Insert", tableName), areaList,
                        commandType: CommandType.StoredProcedure),
                    _=>throw new ArgumentException()
                };
                
                connection.Close();
            }
        }
    }
}
