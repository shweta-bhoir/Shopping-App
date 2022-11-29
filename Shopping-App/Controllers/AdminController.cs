using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_App.Entity;

namespace Shopping_App.Controllers
{
    
    public class AdminController : Controller
    {
        private DataContext Context { get; }

        public AdminController(DataContext context)
        {
            Context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details
        public ActionResult Orders()
        {
            var Orders = Context.Orders.ToList();

            return View(Orders);
        }

        // GET: AdminController/OrderDetails
        public ActionResult OrderDetails(int id)
        {
            var Orders = Context.OrderDetails.Where(x => x.OrderId == id).ToList();

            return View(Orders);
        }

    }
}
