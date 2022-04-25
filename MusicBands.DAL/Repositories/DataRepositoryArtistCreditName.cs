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
    public class DataRepositoryArtistCreditName : IRepositoryArtistCreditName
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DataRepositoryArtistCreditName(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public List<ArtistCreditName> GetData()
        {
            List<ArtistCreditName> artistCreditName = new List<ArtistCreditName>();

            string query = string.Format("SELECT * FROM {0}", "Artist_Credit_Name");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    artistCreditName.Add(new ArtistCreditName()
                    {
                        Artist_Credit = Int32.Parse(reader["Artist_Credit"].ToString()),
                        Position = reader["Position"].ToString(),
                        Artist = Int32.Parse(reader["Artist"].ToString()),
                        Name = reader["Name"].ToString(),
                        Join_Phrase = reader["Join_Phrase"].ToString()
                    });
                }

                connection.Close();
            }

            _log.Info("ArtistCreditName list was returned");

            return artistCreditName;
        }
    }
}
