using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Shopping_App.Entity;
using Shopping_App.Models;
using System.Diagnostics;
using System.Configuration;

namespace Shopping_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext Context { get; }

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            Context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var User = Context.Users.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password) && x.Role.Equals(login.Role)).FirstOrDefault();
            if (User == null)
            {
                ViewData["Error"] = "Invalid User";

            }
            else if (User.Role == "Admin")
            {
                return RedirectToAction("Orders", "Admin");
            }
            else
            {
                TempData["UserId"] = User.UserId;
                
                TempData.Peek("UserId");
                var id = User.UserId;
                return RedirectToAction("Details", "Customer", new { id=id});

            }
            return View("Login");
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {

            user.CreatedOn = DateTime.Now;
            Context.Update(user);
            var isRegistered=Context.SaveChanges();


                if (isRegistered== 1)
                {

                    ViewData["Registered"] = "User is Registered successfully";
                }
                else
                {
                    ViewData["NotRegistered"] = "Error Occured! Please try again";
                }

                return View("Register");
            }
        }

    }
