using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PearlNecklaceDbWebApiConsumerSPA.Models;

namespace PearlNecklaceDbWebApiConsumerSPA.Services
{
    public class PearlNecklaceDbHttpService : BaseHttpService, IPearlNecklaceDbHttpService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public PearlNecklaceDbHttpService()
        {
            _baseUri = new Uri("https://localhost:5001");
            //_baseUri = new Uri("http://localhost:5000");
            _headers = new Dictionary<string, string>();
        }

        public async Task<IEnumerable<INecklace>> GetNecklacesAsync()
        {
            var url = new Uri(_baseUri, "/api/necklaces");
            var response = await SendRequestAsync<List<Necklace>>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<INecklace> GetNecklaceAsync(int necklaceId)
        {
            var url = new Uri(_baseUri, $"/api/necklaces/{necklaceId}");
            var response = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<INecklace> UpdateNecklaceAsync(Necklace necklace)
        {
            var url = new Uri(_baseUri, $"/api/necklaces/{necklace.NecklaceID}");

            //Confirm customer exisit in Database
            var cusToUpdate = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);
            if (cusToUpdate == null)
                return null;  //Customer does not exist

            //Update Customer, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Necklace>(url, HttpMethod.Put, _headers, necklace);

            return necklace;
        }

        public async Task<INecklace> CreateNecklaceAsync(Necklace necklace)
        {
            var url = new Uri(_baseUri, "/api/necklaces");
            var response = await SendRequestAsync<Necklace>(url, HttpMethod.Post, _headers, necklace);

            return response;
        }

        public async Task<INecklace> DeleteNecklaceAsync(int necklaceId)
        {
            var url = new Uri(_baseUri, $"/api/necklaces/{necklaceId}");

            //Confirm customer exisit in Database
            var necklaceToDelete = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);
            if (necklaceToDelete == null)
                return null;  //Customer does not exist

            //Delete Customer, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Necklace>(url, HttpMethod.Delete, _headers);
            return necklaceToDelete;
        }
    }
}
