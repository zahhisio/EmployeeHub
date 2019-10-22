using EmployeeHub.Models.Models;
using EmployeeHub.Services;
using System;
using System.Web.Mvc;

namespace EmployeeHub.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeData db;

        public EmployeeController(IEmployeeData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                db.Add(employee);
                return RedirectToAction("Details", new { id = employee.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee, int id)
        {
            if (ModelState.IsValid)
            {
                db.Update(employee, id);
                return RedirectToAction("Details", new { id = employee.Id });
            }

            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id); if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {

            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}