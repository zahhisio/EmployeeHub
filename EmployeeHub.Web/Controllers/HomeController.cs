using EmployeeHub.Services;
using System.Web.Mvc;

namespace EmployeeHub.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeData db;

        public HomeController(IEmployeeData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}