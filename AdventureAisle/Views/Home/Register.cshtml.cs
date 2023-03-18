using AAClasslibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AdventureAisle.Views.Home
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public IActionResult OnPost()
        {
            TempData["user"] = JsonSerializer.Serialize(user);
            return RedirectToPage("Login");
        }
    }
}
