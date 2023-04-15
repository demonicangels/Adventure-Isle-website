using BusinessLogic;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO Usr { get; set; }

       
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var salt = Security.CreateSalt();
                    var hash = Security.CreateHash(salt, Usr.Password);
                    UserService.InsertUser(Usr, salt, hash);
                    return RedirectToPage("Login");
                }
        }
    }
}
