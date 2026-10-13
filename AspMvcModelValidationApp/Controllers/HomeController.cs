using AspMvcModelValidationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspMvcModelValidationApp.Controllers
{
    public class HomeController : Controller
    {
        static List<Employee> employees = new();

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ModelState"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee.Name == employee.Email)
                ModelState.AddModelError("", "Имя и email не должны совпадать");

            if(ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid().ToString();
                employees.Add(employee);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ModelState"] = ModelState;
                return View();
            }
            
        }
    }
}
