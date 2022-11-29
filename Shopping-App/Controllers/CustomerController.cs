using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_App.Entity;
using Shopping_App.Models;

namespace Shopping_App.Controllers
{
    public class CustomerController : Controller
    {
        private DataContext Context { get; }
        public CustomerController(DataContext context)
        {
            
            Context = context;

        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(OrderDetails details)
        {
            Orders orders= new Orders();
            var userId= Convert.ToInt32(TempData["UserId"]);
            orders.UserId = userId; 
            orders.OrderTotal = details.FinalAmount;
            var OrderBy = Context.Users.Where(x => x.UserId == userId).Select(x=>x.FirstName);
            foreach (var order in OrderBy) {
                orders.OrderBy = order.ToString();
            }   
            orders.OrderDate= DateTime.Now;
           
            Context.Update(orders);
            Context.SaveChanges();

            var orderid = Context.Orders.Where(x => x.UserId == userId).OrderByDescending(x=>x.OrderDate).Select(x => x.OrderId).Take(1);
            foreach (var oid in orderid) {
                details.OrderId = oid;
            }
            
            details.CreatedOn= DateTime.Now;

            Context.Update(details);
            var ordered=Context.SaveChanges();
            if (ordered == 1)
            {
                return RedirectToAction("Details", "Customer", new { id=userId});
            }
            else {
                ViewData["Error"] = "Unable to order. Please try again";
            }
            return View();
        }
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            
            var orderDetails = (from user in Context.Users 
                               join order in Context.Orders on user.UserId equals order.UserId
                               join orderDetail in Context.OrderDetails on order.OrderId equals orderDetail.OrderId
                               where user.UserId== id
                               select new OrderDetails { 
                                 OrderId = orderDetail.OrderId,
                                 ItemName= orderDetail.ItemName,
                                 Qty= orderDetail.Qty,
                                 ItemAmount= orderDetail.ItemAmount,    
                                 DiscountAmount= orderDetail.DiscountAmount,
                                 FinalAmount= orderDetail.FinalAmount,
                               }).ToList();

            return View(orderDetails);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
