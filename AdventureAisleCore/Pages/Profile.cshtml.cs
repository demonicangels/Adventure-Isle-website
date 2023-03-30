using BusinessLogic.Entities;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdventureAisleCore.Pages
{
    public class AccountModel : PageModel
    {
        userRepo userData = new userRepo();
        public UserDTO? Usr { get; set; } = new UserDTO();

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
