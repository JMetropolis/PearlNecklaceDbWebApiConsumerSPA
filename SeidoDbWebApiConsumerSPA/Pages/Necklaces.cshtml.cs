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

        public async Task OnGet()
        {
            Necklaces = await _httpService.GetNecklacesAsync();
            Necklaces = Necklaces.OrderBy(c => c.Name).Take(10);
        }
        public async Task<IActionResult> OnPostDelete(int necklaceId)
        {
            await _httpService.DeleteNecklaceAsync(necklaceId);

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

        public async Task OnPostEdit(int necklaceId)
        {
            UpdatedNecklace = (Necklace)await _httpService.GetNecklaceAsync(necklaceId);
        }

        public async Task<IActionResult> OnPostUpdate(int necklaceId)
        {
            var necklace = (Necklace)await _httpService.GetNecklaceAsync(necklaceId);

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
