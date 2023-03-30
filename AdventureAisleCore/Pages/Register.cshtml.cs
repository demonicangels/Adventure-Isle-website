using AAClasslibrary.Entities;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO Usr { get; set; }


        UserDAO usrData = new UserDAO();
        

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
                    usrData.InsertUser(Usr);
                    return RedirectToPage("Login");
                }
               
        }
    }
}
