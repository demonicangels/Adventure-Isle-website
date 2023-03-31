using BusinessLogic;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class ItalyDestinationsModel : PageModel
    {
        public List<DestinationDTO> Destinations { get; set; }
        public void OnGet()
        {
            DestinationService des = new DestinationService("Italy");
            Destinations = des.GetAllDestinations();
        }
    }
}
