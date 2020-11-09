using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _DBContext;

        public CustomersController()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ActionResult Details(int id)
        {
            var customer = _DBContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            _DBContext.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _DBContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
    }
}