using BusinessLogic;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DAL;
using DAL.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using System.Security.Claims;

namespace AdventureAisleCore.Pages
{
    public class LoginCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO Usr { get; set; }

        IUserRepository _userRepository;


        public LoginCoreModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }





        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid && _userRepository.Authentication(Usr) == true)
            {
                    Usr = _userRepository.GetUserByName(Usr.username);
                    HttpContext.Session.SetInt32("userId", Usr.Id);

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("id", Usr.email),
                        new Claim(ClaimTypes.Name,Usr.username ),
                        new Claim(ClaimTypes.Role, "User"),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

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
