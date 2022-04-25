﻿using MusicBands.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Core.Abstractions
{
    public interface IRepositoryArtist : IRepository<Artist>
    {
        public List<Artist> GetData();
    }
}
