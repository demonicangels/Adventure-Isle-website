using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdventureAisleCore.Pages
{
    public class AccountModel : PageModel
    {
        UserService userService;

        [BindProperty]
        public IFormFile? Imagebytes { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Bio { get; set; }

        public UserDTO Usr { get; set; }= new UserDTO();

        [BindProperty]
        public string IsInEditMode { get; set; }

        public AccountModel(UserService us)
        {
            userService = us;
            
        }
        public void OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if(userId.HasValue)
            {
                Usr = userService.ToDTO(userService.GetUserById((int)userId));
            }
            
        }

       
        public IActionResult OnPost()
        {

			int? userId = HttpContext.Session.GetInt32("userId");
            
            if (userId.HasValue)
            {
                Usr = userService.ToDTO(userService.GetUserById((int)userId));
			}

            if (Imagebytes != null && Imagebytes.Length > 0)
            {
                var memoryStream = new MemoryStream();
                Imagebytes.CopyTo(memoryStream);
                byte[] bindata = memoryStream.ToArray();
				userService.InsertImage(bindata, Usr.Id);
            }

            if (IsInEditMode == "Submit")
            {
                Usr.Username = Username;
                Usr.Bio = Bio;
                var user = userService.FromDTO(Usr);
				userService.UpdateUser(user);
            }
            return RedirectToPage("/Profile");
            
        }
    }
}
