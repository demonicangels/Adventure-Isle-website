using AAClasslibrary.DAL__Operations_;
using AAClasslibrary.Entities;
using AAClasslibrary.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO usr { get; set; }


        UserOperation usrData = new UserOperation();
        

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid) //makes sure the data is valid before sending it 
            {
               
                string sql = "INSERT INTO Users (username,password,email) VALUES (@username,@password,@email)";
                usrData.Insert(sql, usr);
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
                ViewData["Warning"] = "";
            }
        }
    }
}
