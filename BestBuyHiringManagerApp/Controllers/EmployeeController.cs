using BestBuyHiringManagerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestBuyHiringManagerApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var employees = repo.GetAllEmployees();
            return View(employees);
        }
        public IActionResult ViewEmployee(int id)
        {
            var employee = repo.GetEmployee(id);
            return View(employee);
        }
        public IActionResult UpdateEmployee(int id)
        {
            Employee employee = repo.GetEmployee(id);
            if (employee == null)
            {
                return View("EmployeeNotFound");
            }
            return View(employee);
        }

        public IActionResult UpdateEmployeeToDatabase(Employee employee)
        {
            repo.UpdateEmployee(employee);
            return RedirectToAction("ViewEmployee", new { id = employee.EmployeeID });
        }

        public IActionResult InsertEmployee(Employee employeeToInsert)
        {
            var employ = repo.AddEmployee(employeeToInsert);
            return View(employ);
        }

        public IActionResult InsertEmployeeToDatabase(Employee employeeToInsert)
        {
            repo.InsertEmployee(employeeToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
