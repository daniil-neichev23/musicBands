using Dapper;
using Microsoft.Extensions.Configuration;
using MusicBands.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.DAL
{
    public class Reports
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;
        public Reports(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public void GetElementById(int number, IConfigurationRoot root)
        {
            string query = "Place_Area_Report";
            List<PlaceArea> result;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();

                parameters.Add("@id", number, dbType: DbType.Int32, ParameterDirection.Input);

                result = connection.Query<PlaceArea>(query, parameters,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            var json = System.Text.Json.JsonSerializer.Serialize(result);
            File.WriteAllText(root["FilePaths:Element"], json);
        }

        public void CountSongs(int number, IConfigurationRoot root)
        {
            string query = "Artist_Recording_Report";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var param = new DynamicParameters();

                param.Add("@id", number, dbType: DbType.Int32, ParameterDirection.Input);

                var result = connection.Query<int>(query, param,
                    commandType: CommandType.StoredProcedure).First();

                File.WriteAllText(root["FilePaths:CountSongs"], result.ToString());
            }
        }

        public void OddSum(IConfigurationRoot root)
        {
            string query = "Area_Label_Report";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<int>(query,
                    commandType: CommandType.StoredProcedure).First();

                File.WriteAllText(root["FilePaths:OddSum"], result.ToString());
            }
        }
    }
}
