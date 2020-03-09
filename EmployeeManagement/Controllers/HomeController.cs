using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        // / or ~ is used to ignore controller level route attribute
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        [Route("[action]/{id?}")]
        public IActionResult Details(int id)
        {
            var model = _employeeRepository.GetEmployee(id);
            var viewModel = new HomeEmployeeDetailModel
            {
                Employee = model,
                PageTitle = "Employee Details"
            };
            return View(viewModel);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var emp = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = emp.Id });
            }
            return View();
        }
    }
}