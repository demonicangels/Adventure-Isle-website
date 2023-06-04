using BusinessLogic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AdventureAisleCore.Pages
{
    public class LoginCoreModel : PageModel
    {
        UserService userService;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public User Usr { get; set; }

        public User LoggedInUser { get; set; } = new User();




        public LoginCoreModel(UserService usr, IUserRepository user)
        {
			userService = usr;
		}

		public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync() 
        {
            Usr = new User(0,Email, Password);
            LoggedInUser = userService.Authenticate(Usr.Email, Usr.Password);

            if (ModelState.IsValid && LoggedInUser != null)
            {
				HttpContext.Session.SetInt32("userId", (int)LoggedInUser.Id);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim("id", LoggedInUser.Email),
                    new Claim(ClaimTypes.Name, LoggedInUser.Username),
                    new Claim(ClaimTypes.Role, "User"),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToPage("/Index");
            }
            else
            {
                await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["msg"] = "Login failed! Incorrect username or password.";
                return RedirectToPage("/Login");
            }

        }
        
    }
}
