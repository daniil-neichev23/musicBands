using Microsoft.Extensions.Configuration;
using MusicBands.Core;
using MusicBands.Core.Abstractions;
using MusicBands.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.DAL.Repositories
{
    public class DataRepositoryRecording : IRepositoryRecording
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DataRepositoryRecording(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public List<Recording> GetData()
        {
            List<Recording> record = new List<Recording>();
            string query = string.Format("SELECT * FROM {0}", "Recording");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    record.Add(new Recording()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        GId = Int32.Parse(reader["GId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Artist_Credit = Int32.Parse(reader["Artist_Credit"].ToString()),
                        Length = Int32.Parse(reader["Length"].ToString()),
                        Comment = reader["Comment"].ToString(),
                        Edits_Pending = Boolean.Parse(reader["Edits_Pending"].ToString()),
                        Last_Updated = Convert.ToDateTime(reader["Last_Updated"].ToString())
                    });
                }
                connection.Close();
            }
            _log.Info("Recording list was returned");

            return record;
        }
    }
}
