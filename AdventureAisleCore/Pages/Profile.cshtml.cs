using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdventureAisleCore.Pages
{
    public class AccountModel : PageModel
    {
        IUserRepository _userRepository;
        public AccountModel(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        [BindProperty]
        public IFormFile? Imagebytes { get; set; }
        
        public UserDTO? Usr { get; set; } = new UserDTO();

        public IActionResult OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId.HasValue)
            {
                Usr = _userRepository.GetUserById((int)userId);
            }
            return Page();
        }


        public void OnPost()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId.HasValue)
            {
                Usr = _userRepository.GetUserById((int)userId);
            }

            if (Imagebytes != null)
            {
                var memoryStream = new MemoryStream();
                Imagebytes.CopyTo(memoryStream);
                byte[] bindata = memoryStream.ToArray();
                _userRepository.InsertImage(bindata, Usr.username);
            }
        }
    }
}
