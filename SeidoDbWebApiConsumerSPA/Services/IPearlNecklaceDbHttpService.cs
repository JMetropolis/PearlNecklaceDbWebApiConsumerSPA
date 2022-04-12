using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PearlNecklaceDbWebApiConsumerSPA.Models;

namespace PearlNecklaceDbWebApiConsumerSPA.Services
{
    public interface IPearlNecklaceDbHttpService
    {
        Task<IEnumerable<INecklace>> GetNecklacesAsync();
        Task<INecklace> GetNecklaceAsync(int necklaceId);

        Task<INecklace> UpdateNecklaceAsync(Necklace necklace);

        Task<INecklace> CreateNecklaceAsync(Necklace necklace);
        Task<INecklace> DeleteNecklaceAsync(int necklaceId);
    }
}
