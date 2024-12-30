using EmployeAttendenceManagementSystem.Data;
using EmployeAttendenceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeAttendenceManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext context;
        public AttendanceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result = context.Attendances.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Attendance model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Attendance()
                {
                    EmployeeId = model.EmployeeId,
                    Date = model.Date,
                    CheckInTime = model.CheckInTime,
                    CheckOutTime = model.CheckOutTime
                };
                context.Attendances.Update(emp);
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
            var emp = context.Attendances.SingleOrDefault(e =>e.EmployeeId == id);
            context.Attendances.Remove(emp);
            context.SaveChanges();
            TempData["Error"] ="Data Deleted!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Attendances.SingleOrDefault(e => e.AttendanceId == id);
            var result = new Attendance()
            {
                EmployeeId= emp.EmployeeId,
                Date=emp.Date,
                CheckInTime=emp.CheckInTime,
                CheckOutTime=emp.CheckOutTime
                
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Attendance model)
        {
            var emp = new Attendance()
            {
                EmployeeId = model.EmployeeId,
                Date = model.Date,
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime
            };
            context.Attendances.Update(emp);
            context.SaveChanges();
            TempData["Error"] = "Data Updated Sucessfully";
            return RedirectToAction("Index");
        }

    }
}
