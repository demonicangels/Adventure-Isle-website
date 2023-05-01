using BusinessLogic;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationsModel : PageModel
    {
        DestinationService destinationService;
        ReviewService reviewService;

        [BindProperty(SupportsGet = true)]
        public string Country { get; set; }

        //[FromQuery(Name = "number")]
        // .../Destination?number=1
        
        public static List<Destination>? Destination { get; set; }

        public Review[][] AllReviews { get; set; }

        public void OnGet()
        {
            destinationService = serviceObjects.destinationServiceObject();
            reviewService = serviceObjects.reviewServiceObject();


			var result = HttpContext.Session.GetString("search");

			if (!String.IsNullOrEmpty(Country))
            {
                Destination = destinationService.GetAllDestinationsByCountry(Country);
            }
            else if (!String.IsNullOrEmpty(result))
            {
				Destination = destinationService.GetDestinationByName(result);
			}

            AllReviews = new Review[Destination.Count][];
            for (int i = 0; i < Destination.Count; i++)
            {
                AllReviews[i] = reviewService.GetReviews(Destination[i].Name);
            }
        }
    }
}
