using AAClasslibrary.Entities;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class FranceDestinationsModel : PageModel
    {
        public List<Destination> Destinations { get; set; }
        public void OnGet()
        {
            DestinationDAO des = new DestinationDAO();
            Destinations = des.GetAllDestinations();
        }
    }
}
