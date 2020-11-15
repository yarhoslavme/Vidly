using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Yarhoslav ME"},
            new Customer { Id = 2, Name = "Carmen QH"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var model = new CustomersViewModel
            {
                Customers = customers
            };

            return View(model);
        }

        [Route("customers/details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            var customer = customers.Where(x => x.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}