using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;



namespace AdventureAisleCore.Pages
{
    public class LoginCoreModel : PageModel
    {
        UserService usrData = new UserService();

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
                if (usrData.TryLogin(Usr) == true)
                {

                    Usr = usrData.GetUserByName(Usr.username);
                    HttpContext.Session.SetInt32("userId", Usr.Id);
                    return RedirectToPage("/Profile");
                }
                else
                {
                    TempData["msg"] = "Login failed! Incorrect username or password.";

                    return Page();
                }
            }

        }
        
    }
}
