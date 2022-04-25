using Microsoft.Extensions.Configuration;
using MusicBands.Core.Data;
using MusicBands.Core.UsableStrings;
using MusicBands.DAL.Repositories;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBands.Core.Abstractions;

namespace MusicBands.Core
{
    public class DataFactory
    {
        private readonly IRepository<Area> _repositoryArea;
        private readonly IRepository<Artist> _repositoryArtist;
        private readonly IRepository<ArtistCredit> _repositoryArtistCredit;
        private readonly IRepository<ArtistCreditName> _repositoryArtistCreditName;
        private readonly IRepository<Label> _repositoryLabel;
        private readonly IRepository<Place> _repositoryPlace;
        private readonly IRepository<Recording> _repositoryRecording;

        public DataFactory(IRepositoryArea repositoryArea, IRepositoryArtist repositoryArtist, 
            IRepositoryArtistCredit repositoryArtistCredit, IRepositoryArtistCreditName repositoryArtistCreditName,
            IRepositoryLabel repositoryLabel, IRepositoryPlace repositoryPlace,
            IRepositoryRecording repositoryRecording)
        {
            _repositoryArea = repositoryArea;
            _repositoryArtist = repositoryArtist;
            _repositoryArtistCredit = repositoryArtistCredit;
            _repositoryArtistCreditName = repositoryArtistCreditName;
            _repositoryLabel = repositoryLabel;
            _repositoryPlace = repositoryPlace;
            _repositoryRecording = repositoryRecording;
        }
        public IEnumerable<Entity> GetDataFromDb(string tableName, IConfigurationRoot root)
        {
            if (tableName == Commands.Area)
            {
                return _repositoryArea.GetData();
            }
            if (tableName == Commands.Artist)
            {
                return _repositoryArtist.GetData();
            }
            if (tableName == Commands.ArtistCredit)
            {
                return _repositoryArtistCredit.GetData();
            }
            if (tableName == Commands.ArtistCreditName)
            {
                return _repositoryArtistCreditName.GetData();
            }
            if (tableName == Commands.Label)
            {
                return _repositoryLabel.GetData();
            }
            if (tableName == Commands.Place)
            {
                return _repositoryPlace.GetData();
            }
            if (tableName == Commands.Recording)
            {
                return _repositoryRecording.GetData();
            }
            else
            {
                return null;
            }
        }
    }
}
