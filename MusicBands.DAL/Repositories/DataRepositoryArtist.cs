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
    public class DataRepositoryArtist : IRepositoryArtist
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;
        public DataRepositoryArtist(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }
        public List<Artist> GetData()
        {
            List<Artist> artist = new List<Artist>();

            string query = string.Format("SELECT * FROM {0}", "Artist");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    artist.Add(new Artist()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        GId = Int32.Parse(reader["GId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Sort_Name = reader["Sort_Name"].ToString(),
                        Begin_Date_Year = Int32.Parse(reader["Begin_Date_Year"].ToString()),
                        Begin_Date_Month = Int32.Parse(reader["Begin_Date_Month"].ToString()),
                        Begin_Date_Day = Int32.Parse(reader["Begin_Date_Day"].ToString()),
                        End_Date_Year = Int32.Parse(reader["End_Date_Year"].ToString()),
                        End_Date_Month = Int32.Parse(reader["End_Date_Month"].ToString()),
                        End_Date_Day = Int32.Parse(reader["End_Date_Day"].ToString()),
                        Ended = Convert.ToBoolean(reader["Ended"].ToString()),
                        Type = Int32.Parse(reader["Type"].ToString()),
                        Area = Int32.Parse(reader["Area"].ToString()),
                        Begin_Area = reader["Begin_Area"].ToString(),
                        End_Area = reader["End_Area"].ToString(),
                        Comment = reader["Comment"].ToString(),
                        Edits_Pending = Convert.ToBoolean(reader["Edits_Pending"].ToString()),
                        Last_Updated = Convert.ToDateTime(reader["Last_Updated"].ToString()),
                        Gender = Boolean.Parse(reader["Gender"].ToString())
                    });

                }

                connection.Close();
            }
            _log.Info("Artist list was returned");

            return artist;
        }
    }
}
