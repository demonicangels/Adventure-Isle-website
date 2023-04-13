using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Country { get; set; }

        IDestinationRepository _destinationRepository;
        public List<DestinationDTO>? Destination { get; set; } = new List<DestinationDTO>();

        public DestinationsModel(IDestinationRepository destinationRepository) 
        {
            _destinationRepository = destinationRepository;
        }
       
        public void OnGet()
        {
			var result = HttpContext.Session.GetString("search");

			if (!String.IsNullOrEmpty(Country))
            {
                Destination = (_destinationRepository.GetAllDestinationsByCountry(Country));
            }
            else if (!String.IsNullOrEmpty(result))
            {
				Destination.Add(_destinationRepository.GetDestinationByName(result));
			}
		}
    }
}
