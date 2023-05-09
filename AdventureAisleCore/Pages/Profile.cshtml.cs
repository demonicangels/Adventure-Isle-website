using BusinessLogic;
using Factory;
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
        public void OnGet()
        {
            userService = serviceObjects.userServiceObject();

            int? userId = HttpContext.Session.GetInt32("userId");

            if(userId.HasValue)
            {
                Usr = userService.ToDTO(userService.GetUserById((int)userId));
            }
            
        }

       
        public IActionResult OnPost()
        {
			userService = serviceObjects.userServiceObject();

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
				userService.InsertImage(bindata, Usr.Username);
            }

            if (IsInEditMode == "Submit")
            {
                Usr.Username = Username;
                Usr.Bio = Bio;
                var user = userService.FromDTO(Usr);
				userService.UpdateUser(user);
            }
            return Page();
            
        }
    }
}
