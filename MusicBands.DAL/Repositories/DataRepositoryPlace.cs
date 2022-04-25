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
    public class DataRepositoryPlace : IRepositoryPlace
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DataRepositoryPlace(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public List<Place> GetData()
        {
            List<Place> place = new List<Place>();

            string query = string.Format("SELECT * FROM {0}", "Place");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    place.Add(new Place()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        GId = Int32.Parse(reader["GId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Type = Int32.Parse(reader["Type"].ToString()),
                        Address = reader["Address"].ToString(),
                        Area = Int32.Parse(reader["Area"].ToString()),
                        Comment = reader["Comment"].ToString(),
                        Begin_Date_Year = Int32.Parse(reader["Begin_Date_Year"].ToString()),
                        Begin_Date_Month = Int32.Parse(reader["Begin_Date_Month"].ToString()),
                        Begin_Date_Day = Int32.Parse(reader["Begin_Date_Day"].ToString()),
                        End_Date_Year = Int32.Parse(reader["End_Date_Year"].ToString()),
                        End_Date_Month = Int32.Parse(reader["End_Date_Month"].ToString()),
                        End_Date_Day = Int32.Parse(reader["End_Date_Day"].ToString()),
                        Ended = Boolean.Parse(reader["Ended"].ToString()),
                        Edits_Pending = Boolean.Parse(reader["Edits_Pending"].ToString()),
                        Last_Updated = Convert.ToDateTime(reader["Last_Updated"].ToString()),
                        Coordinates = reader["Coordinates"].ToString()
                    });
                }

                connection.Close();
            }

            _log.Info("Place list was returned");

            return place;
        }
    }
}
