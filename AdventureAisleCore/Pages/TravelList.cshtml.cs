using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    [Authorize]
    public class TravelListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
