using BusinessLogic;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class DestinationResultModel : PageModel
    {
        public List<DestinationDTO>? Destination { get; set; } = new List<DestinationDTO>();

        DestinationService des = new DestinationService("");
        public void OnGet()
        {
            var result = HttpContext.Session.GetString("search");
            if(!String.IsNullOrEmpty(result))
            {
                Destination.Add(des.GetDestinationByName(result));
            } 
        }
    }
}
