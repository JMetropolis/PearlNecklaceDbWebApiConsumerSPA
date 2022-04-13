using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PearlNecklaceDbWebApiConsumerSPA.Models;
using PearlNecklaceDbWebApiConsumerSPA.Services;

namespace PearlNecklaceDbWebApiConsumerSPA.Pages
{
    public class NecklacesModel : PageModel
    {
        IPearlNecklaceDbHttpService _httpService;

        public IEnumerable<INecklace> Necklaces { get; private set; }

        public string ConnectedService => AppConfig.ConfigurationRoot.GetConnectedDbService();

        public async Task OnGet()
        {
            Necklaces = await _httpService.GetNecklacesAsync();
            Necklaces = Necklaces.OrderBy(c => c.Name).Take(10);
        }
        public async Task<IActionResult> OnPostDelete(string necklaceId) //zero()
        {
            int intID = Int32.Parse(necklaceId);
            await _httpService.DeleteNecklaceAsync(intID);

            return RedirectToPage("/necklaces");
        }

        #region Create
        [BindProperty]
        public Necklace NewNecklace { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if ((NewNecklace != null) && ModelState.IsValid)
            {
                await _httpService.CreateNecklaceAsync(NewNecklace);
            }
            return RedirectToPage("/necklace");
        }
        #endregion

        #region Update
        [BindProperty]
        public Necklace UpdatedNecklace { get; set; }

        public async Task OnPostEdit(string necklaceId)
        {
            int intID = Int32.Parse(necklaceId);
            UpdatedNecklace = (Necklace)await _httpService.GetNecklaceAsync(intID);
        }

        public async Task<IActionResult> OnPostUpdate(string necklaceId)
        {
            int intID = Int32.Parse(necklaceId);
            var necklace = (Necklace)await _httpService.GetNecklaceAsync(intID);

            //necklace.Copy(UpdatedNecklace);
            await _httpService.UpdateNecklaceAsync(necklace);

            return RedirectToPage("/necklaces");
        }
        #endregion

        public NecklacesModel()//IPearlNecklaceDbHttpService service)
        {
            this._httpService = new PearlNecklaceDbHttpService();// service;
        }
    }
}
