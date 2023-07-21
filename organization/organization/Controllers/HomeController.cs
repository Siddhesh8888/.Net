using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using organization.Models;
using System.Diagnostics;

namespace organization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Employee()
        {
            List<Employee> emplist= DBManager.GetAllEmployees();
            ViewBag.ListOfEmployee = emplist;
            return View();
        }

        [HttpPost]
        public IActionResult Register(string id,string name, string designation, string department, string city, string salary)
        {
            Employee newEmp = new Employee(int.Parse(id), name, designation, department, city, double.Parse(salary));
            DBManager.AddEmployee(newEmp);
            return RedirectToAction("Employee");
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}