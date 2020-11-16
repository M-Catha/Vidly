using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult Edit(int id)
        {
            var customer = _DBContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _DBContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            var customers = _DBContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _DBContext.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _DBContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            // New customer
            if (customer.Id == 0)
            {
                _DBContext.Customers.Add(customer);
            }
            // Existing customer
            else
            {
                var existingCustomer = _DBContext.Customers.Single(c => c.Id == customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.Birthdate = customer.Birthdate;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}