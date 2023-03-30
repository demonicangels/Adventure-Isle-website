using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO Usr { get; set; }


        UserService usrData = new UserService();
        

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
