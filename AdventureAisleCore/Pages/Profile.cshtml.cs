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

        public User Usr { get; set; }= new User();

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
                Usr = userService.GetUserById((int)userId);
            }
            
        }

       
        public IActionResult OnPost()
        {

			int? userId = HttpContext.Session.GetInt32("userId");
            
            if (userId.HasValue)
            {
                Usr = userService.GetUserById((int)userId);
			}

            if (Imagebytes != null && Imagebytes.Length > 0)
            {
                var memoryStream = new MemoryStream();
                Imagebytes.CopyTo(memoryStream);
                byte[] bindata = memoryStream.ToArray();
				Usr = userService.InsertImage(bindata, (int)userId);
            }

            if (IsInEditMode == "Submit")
            {
                Usr.Username = Username;
                Usr.Bio = Bio;
				userService.UpdateUser(Usr);
            }
            return Page();
            
        }
    }
}
