using AAClasslibrary.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdventureAisleCore.Pages
{
    public class AccountModel : PageModel
    {
        UserDAO userData = new UserDAO();
        public User? Usr { get; set; } = new User();

        public IActionResult OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId.HasValue)
            {
                Usr = userData.GetUserById((int)userId);
            }
            return Page();
        }
    }
}
