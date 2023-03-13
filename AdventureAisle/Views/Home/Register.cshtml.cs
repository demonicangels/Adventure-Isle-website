using AAClasslibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisle.Views.Home
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public void OnPost()
        {
            user.username = Request.Form["username"];
            user.password = Request.Form["psw"];
           
        }
    }
}
