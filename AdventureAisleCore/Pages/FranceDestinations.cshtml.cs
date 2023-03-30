using BusinessLogic;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class FranceDestinationsModel : PageModel
    {
        public List<DestinationDTO> Destinations { get; set; }
        public void OnGet()
        {
            DestinationService des = new DestinationService();
            Destinations = des.GetAllDestinations();
        }
    }
}
