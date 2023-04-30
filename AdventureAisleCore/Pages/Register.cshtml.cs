using BusinessLogic;
using BusinessLogic.Entities;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        UserService userService;
        Security security = new Security();

        [BindProperty]
        public UserDTO Usr { get; set; }

       
        public void OnGet()
        {
            userService = serviceObjects.userServiceObject();
        }
        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var salt = security.CreateSalt();
                    var hash = security.CreateHash(salt, Usr.Password);
				    userService.InsertUser(Usr, salt, hash);
                    return RedirectToPage("Login");
                }
        }
    }
}
