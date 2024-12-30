using EmployeAttendenceManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using EmployeAttendenceManagementSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EmployeAttendenceManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result=context.Employees.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    EmployeeId=model.EmployeeId,
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department
                }; 
                context.Employees.Update(emp);
                context.SaveChanges();
                TempData["Error"] = "Data Saved Sucessfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty field can't submit";
                return View(model);
            }
              
            
        }
      
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e=>e.EmployeeId==id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["Error"] = "Data Deleted!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            var result = new Employee()
            {
                Name = emp.Name,
                Email = emp.Email,
                Department = emp.Department
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                EmployeeId = model.EmployeeId,
                Name = model.Name,
                Email = model.Email,
                Department = model.Department
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["Error"] = "Data Updated Sucessfully";
            return RedirectToAction("Index");
        }
    }
}
