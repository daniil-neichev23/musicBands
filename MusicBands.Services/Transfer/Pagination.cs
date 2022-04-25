using MusicBands.Core.Data;
using MusicBands.Core.UsableStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBands.Services.Transfer
{
    public class Pagination
    {
        public static List<Entity> Paging(List<Entity> listOfEntities, string pages, string quantity)
        {
            int totalPages = 0;
            int index = 0;
            int numberOfItemsPerPage = 1000;

            if (string.IsNullOrEmpty(quantity) && string.IsNullOrEmpty(pages))
            {
                return listOfEntities.GetRange(index, numberOfItemsPerPage);
            }
            else if (string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(pages))
            {
                int page = int.Parse(pages);
                totalPages = (int)Math.Ceiling((double)listOfEntities.Count / numberOfItemsPerPage);
                if (page > totalPages || page <= 0) throw new ArgumentOutOfRangeException();
                index = (page - 1) * numberOfItemsPerPage;
                int numberOfElements = listOfEntities[index + numberOfItemsPerPage] != null ? numberOfItemsPerPage : listOfEntities.Count - index;
                return listOfEntities.GetRange(index, numberOfElements);
            }
            else if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(pages))
            {
                int page = int.Parse(pages);
                int quant = int.Parse(quantity);
                totalPages = (int)Math.Ceiling((double)listOfEntities.Count / quant);
                if (page > totalPages || page <= 0) throw new ArgumentOutOfRangeException();
                if (quant <= 0) throw new ArgumentOutOfRangeException();
                index = (page - 1) * quant;
                int numberOfElements = listOfEntities[index+quant] != null ? quant : listOfEntities.Count - index;
                return listOfEntities.GetRange(index, numberOfElements);
            }

            return listOfEntities;
        }
    }
}
