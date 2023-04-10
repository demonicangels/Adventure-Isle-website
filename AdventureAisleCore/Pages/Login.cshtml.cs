using BusinessLogic;
using BusinessLogic.Entities;
using DAL.Interfaces;
using DAL.DTOs;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AdventureAisleCore.Pages
{
    public class LoginCoreModel : PageModel
    {
        [BindProperty]
        public User Usr { get; set; }




        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid && BusinessLogic.Entities.User.Authenticate(Usr) == true)
            {

                Usr = BusinessLogic.Entities.User.GetUserByEmail(Usr.Email);
                HttpContext.Session.SetInt32("userId", (int)Usr.Id);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("id", Usr.Email),
                        new Claim(ClaimTypes.Name, Usr.Username),
                        new Claim(ClaimTypes.Role, "User"),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    return base.RedirectToPage("/Profile");

            }
            else
            {
                TempData["msg"] = "Login failed! Incorrect username or password.";
                return base.Page();
            }

        }
        
    }
}
