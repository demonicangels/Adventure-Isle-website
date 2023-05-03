using BusinessLogic;
using BusinessLogic.Entities;
using Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdventureAisleCore.Pages
{
    [Authorize(Roles = "User")]
    public class TravelListModel : PageModel
    {
        TravelListService tr;
        TravelList list = new TravelList();

        [BindProperty]
        public List<Necessity> Necessities { get; set; } = new List<Necessity>();
        public IActionResult OnGet()
        {
            tr = serviceObjects.travelListServiceObject();
            if (User.IsInRole("User"))
            {
                var usrId = HttpContext.Session.GetInt32("userId");
                list = tr.GetListByUserId((int)usrId);
                Necessities = list.Necessities;
                return Page();
            }
            return Unauthorized();
        }
        public IActionResult OnPost(List<string>item)
        {
            tr = serviceObjects.travelListServiceObject();
            var usrId = HttpContext.Session.GetInt32("userId");
            list = tr.GetListByUserId((int)usrId);
            foreach (var s in item)
            {
                var nes = new Necessity
                {
                    Name = s,
                };

               Necessities.Add(nes);
            }
            if(list.Id != 0)
            {
                list.Necessities = Necessities;
                list = tr.UpdateTravelList(list);
            }
            else
            {
                list.UserId = (int)HttpContext.Session.GetInt32("userId");
                list.Necessities = Necessities;
                list = tr.CreateList(list);
            }
            return RedirectToPage("TravelList");

        }
    }
}
