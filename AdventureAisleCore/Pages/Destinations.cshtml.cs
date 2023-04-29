using BusinessLogic;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationsModel : PageModel
    {
        DestinationService destinationService;
        [BindProperty(SupportsGet = true)]
        public string Country { get; set; }

        //[FromQuery(Name = "number")]
        // .../Destination?number=1



        public List<Destination>? Destination { get; set; } 
       
        public void OnGet()
        {
            destinationService = serviceObjects.destinationServiceObject();

			var result = HttpContext.Session.GetString("search");

			if (!String.IsNullOrEmpty(Country))
            {
                Destination = destinationService.GetAllDestinationsByCountry(Country);
            }
            else if (!String.IsNullOrEmpty(result))
            {
				Destination = destinationService.GetDestinationByName(result);
			}
		}
    }
}
