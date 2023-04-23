using BusinessLogic;
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

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Bio { get; set; }

        public UserDTO Usr { get; set; }= new UserDTO();

        [BindProperty]
        public string IsInEditMode { get; set; }
        public void OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId.HasValue)
            {
                Usr = _userRepository.GetUserById((int)userId);
            }
            
        }

       
        public IActionResult OnPost()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            
            if (userId.HasValue)
            {
                Usr = _userRepository.GetUserById((int)userId);
            }

            if (Imagebytes != null && Imagebytes.Length > 0)
            {
                var memoryStream = new MemoryStream();
                Imagebytes.CopyTo(memoryStream);
                byte[] bindata = memoryStream.ToArray();
                _userRepository.InsertImage(bindata, Usr.Username);
            }

            if (IsInEditMode == "Submit")
            {
                Usr.Username = Username;
                Usr.Bio = Bio;
                var user = UserService.FromDTO(Usr);
                UserService.UpdateUser(user);
            }
            return Page();
            
        }
    }
}
