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
    public class DataRepositoryArtistCredit : IRepositoryArtistCredit
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString;

        public DataRepositoryArtistCredit(IConfigurationRoot iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }

        public List<ArtistCredit> GetData()
        {
            List<ArtistCredit> artistCredit = new List<ArtistCredit>();

            string query = string.Format("SELECT * FROM {0}", "Artist_Credit");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                _log.Info("The connection was opened successfully");

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    artistCredit.Add(new ArtistCredit()
                    {
                        Id = Int32.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Artist_Count = Int32.Parse(reader["Artist_Count"].ToString()),
                        Ref_Count = Int32.Parse(reader["Ref_Count"].ToString()),
                        Created = Boolean.Parse(reader["Created"].ToString()),
                    });
                }

                connection.Close();
            }

            _log.Info("ArtistCredit list was returned");

            return artistCredit;
        }
    }
}
