using Dapper;
using Microsoft.Extensions.Configuration;
using MusicBands.Core;
using MusicBands.Core.Abstractions;
using MusicBands.Core.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.DAL.Repositories
{
    public class DataRepositoryArea : IRepositoryArea

    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DataRepositoryArea(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public List<Area> GetData()
        {
            List<Area> area = new List<Area>();

            string query = string.Format("SELECT * FROM {0}", "Area");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    area.Add(new Area()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        GId = Int32.Parse(reader["GId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Sort_Name = reader["Sort_Name"].ToString(),
                        Type = Int32.Parse(reader["Type"].ToString()),
                        Begin_Date_Year = Int32.Parse(reader["Begin_Date_Year"].ToString()),
                        Begin_Date_Month = Int32.Parse(reader["Begin_Date_Month"].ToString()),
                        Begin_Date_Day = Int32.Parse(reader["Begin_Date_Day"].ToString()),
                        End_Date_Year = Int32.Parse(reader["End_Date_Year"].ToString()),
                        End_Date_Month = Int32.Parse(reader["End_Date_Month"].ToString()),
                        End_Date_Day = Int32.Parse(reader["End_Date_Day"].ToString()),
                        Ended = Boolean.Parse(reader["Ended"].ToString()),
                        Comment = reader["Comment"].ToString(),
                        Edits_Pending = Boolean.Parse(reader["Edits_Pending"].ToString()),
                        Last_Updated = Convert.ToDateTime(reader["Last_Updated"].ToString())
                    });
                }

                connection.Close();
            }

            _log.Info("Area list was returned");

            return area;
        }
    }
}
