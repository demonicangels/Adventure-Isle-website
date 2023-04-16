using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Country { get; set; }


        public List<Destination>? Destination { get; set; } 
       
        public void OnGet()
        {
			var result = HttpContext.Session.GetString("search");

			if (!String.IsNullOrEmpty(Country))
            {
                Destination = DestinationService.GetAllDestinationsByCountry(Country);
            }
            else if (!String.IsNullOrEmpty(result))
            {
				Destination = DestinationService.GetDestinationByName(result);
			}
		}
    }
}
