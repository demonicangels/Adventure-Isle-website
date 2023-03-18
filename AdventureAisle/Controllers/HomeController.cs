using AAClasslibrary.Entities;
using AAClasslibrary.Operations;
using AdventureAisle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;



namespace AdventureAisle.Controllers
{

    public class HomeController : Controller
    {
        OUser login = new OUser("");
        
        [BindProperty]
        public User user { get; set; } = new User();

        
        






        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Countries() 
        { 
            return View();
        }
        public IActionResult Privacy()
        {
            ViewBag.Title = "Privacy policy";
            return View();
        }
        public IActionResult Login(User user)
        {
            return View();
        }
        public IActionResult LoginFormValidate(User user)
        {
            if (Request.Form["user"] != user.GetUserName && Request.Form["pass"] != user.GetPassword)
            {
                TempData["msg"] = "Your username or password are incorrect.";
                return View("Login");

            }
            else
            {
                return View("Countries");
            }
            return View("Login");

            //<label for="psw"><b>Email</b></label>
            //< input asp -for= "email" class="pass" type="email" placeholder="Enter your email" name="email" required>
            //var res = LoginCheck();
            //if (res == true)
            //{
            //    return View("Countries");
            //}
            //else
            //{
            //    TempData["msg"] = "Your username or password are incorrect.";
            //	return View("Login");
            //}


        }
        public IActionResult Register() 
        {
            return View();
        }

		//public bool LoginCheck()
		//{
		//	var boolResult = true;
		//	string connecctionString = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;TrustServerCertificate=True";
        //    using (SqlConnection con = new SqlConnection(connecctionString))
        //    {
        //        con.Open();
        //        string sql = "SELECT* FROM LoginData";
        //        using (SqlCommand com = new SqlCommand(sql, con)) //allows to execute the command we gave to the database and get all data
        //        {
        //            using (SqlDataReader reader = com.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var username = Request.Form["user"];
        //                    var password = Request.Form["passwor"];
        //
        //                    if (username != us.username || password != us.password)
        //                    {
        //                        boolResult = false;
        //                        return boolResult;
        //                    }
        //                    
        //
        //                }
        //
        //            }
        //        }  
        //    } 
        //    return boolResult;
        //}  
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}