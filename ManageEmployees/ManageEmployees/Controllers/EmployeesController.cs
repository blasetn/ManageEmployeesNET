using DAL.Database;
using BLL.Interfaces;
using ManageEmployees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models.Employee;

namespace ManageEmployees.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ManageEmployeesDatabaseContext _context;
        private readonly IEmployeesServices _employeeService;
        public EmployeesController(ManageEmployeesDatabaseContext context, IEmployeesServices employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeViewModel> employees = Enumerable.Empty<EmployeeViewModel>();
            employees = _employeeService.GetAll();
            return View(employees);
        }

        [HttpPost]
        public JsonResult Create(EmployeeCreateModel employee)
        {
            return Json(_employeeService.Create(employee));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            return Json(_employeeService.Delete(id));
        }

        public IActionResult Privacy()
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
