using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            var model = new CustomersViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };

            return View(model);
        }

        [Route("customers/details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}