using AAClasslibrary.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace AdventureAisleCore.Pages
{
    public class LoginCoreModel : PageModel
    {
        UserOperation usrData = new UserOperation();

        [BindProperty]
        public string Usrname { get; set; }

        [BindProperty]
        public string Pass { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost() 
        {
            var sql = "SELECT username, password FROM Users";
            
            if (usrData.TryLogin(sql, Usrname, Pass) == true)
            {
                return RedirectToPage("/France");
            }
            return Page();
        }
    }
}
