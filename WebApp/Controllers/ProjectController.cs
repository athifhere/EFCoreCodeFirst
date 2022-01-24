using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProjectController : Controller
    {
        ProjectContext _db;

        public ProjectController(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.AccountList = _db.Accounts.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            if(ModelState.IsValid)
            {
                _db.Employees.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }           
            
            ViewBag.AccountList = _db.Accounts.ToList();

            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = _db.Employees.Find(id);

            ViewBag.AccountList = _db.Accounts.ToList();

            return View("Create", employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountList = _db.Accounts.ToList();

            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);

            if(employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
