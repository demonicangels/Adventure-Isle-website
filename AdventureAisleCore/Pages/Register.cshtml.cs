using BusinessLogic;
using BusinessLogic.Entities;
using DAL.Interfaces;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RegisterCoreModel : PageModel
    {
        [BindProperty]
        public UserDTO Usr { get; set; }
        IUserRepository _userRepository;


        public RegisterCoreModel(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

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
                    _userRepository.InsertUser(Usr);
                    return RedirectToPage("Login");
                }
               
        }
    }
}
