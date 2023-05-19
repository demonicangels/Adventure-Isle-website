using BusinessLogic;
using BusinessLogic.Interfaces;
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

        public Review[][] AllCurrentDesReviews { get; set; }

        public DestinationsModel(DestinationService des, ReviewService reviewService)
        {
			destinationService = des;
            this.reviewService = reviewService;
           
		}
        public void OnGet()
        {
			var result = HttpContext.Session.GetString("search");

			if (!String.IsNullOrEmpty(Country))
            {
                Destination = destinationService.GetAllDestinationsByCountry(Country);
            }
            else if (!String.IsNullOrEmpty(result))
            {
				Destination = destinationService.GetDestinationByName(result);  
			}

			AllCurrentDesReviews = new Review[Destination.Count][];
            for (int i = 0; i < Destination.Count; i++)
            {
				AllCurrentDesReviews[i] = reviewService.GetReviewsByDesId(Destination[i].Id);
            }
        }
    }
}
