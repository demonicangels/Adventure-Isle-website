using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationResultModel : PageModel
    {
        IDestinationRepository _destinationRepository;
        public List<DestinationDTO>? Destination { get; set; } = new List<DestinationDTO>();
        public DestinationResultModel(IDestinationRepository destinationRepository)
        {
           _destinationRepository = destinationRepository;
        }

        public void OnGet()
        {
            var result = HttpContext.Session.GetString("search");
            if(!String.IsNullOrEmpty(result))
            {
                Destination.Add(_destinationRepository.GetDestinationByName(result));
            } 
        }
    }
}
