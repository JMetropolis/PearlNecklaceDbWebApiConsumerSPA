using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PearlNecklaceDbWebApiConsumerSPA.Models;
using PearlNecklaceDbWebApiConsumerSPA.Services;

namespace PearlNecklaceDbWebApiConsumerSPA.Pages
{
    public class PearlsModel : PageModel
    {
        IPearlNecklaceDbHttpService _httpService;
        public Necklace Necklace { get; private set; }

        public async Task OnGet(string NecklaceID)
        {
            var neckID = Int32.Parse(NecklaceID);
            Necklace = (Necklace)await _httpService.GetNecklaceAsync(neckID);
        }

        public PearlsModel(IPearlNecklaceDbHttpService service)
        {
            this._httpService = new PearlNecklaceDbHttpService();// service;
        }
    }
}
