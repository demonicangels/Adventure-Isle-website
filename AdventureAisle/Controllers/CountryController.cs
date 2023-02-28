using Microsoft.AspNetCore.Mvc;

namespace AdventureAisle.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult France()
        {
            return View();
        }
    }
}
