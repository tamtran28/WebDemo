using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WebDemo.Models;
//using System.Data.SqlClie;
namespace WebDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private testContext db = new testContext();
        public IActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Position).ToList();
            var sortedEmployees = employees.OrderBy(e => e.Birthday).ThenBy(e => e.LastName);
            return View(sortedEmployees);
        }
        public IActionResult Add(Employee e)
        {
            if ((DateTime.Now.Year - e.Birthday.Year) < 18)
            {
                ModelState.AddModelError("Birthday", "Employee must be at least 18 years old.");
                ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId", e.DepartmentId);
                ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "PositionId", e.PositionId);
                return View("AddEmployee", e);
            }
            else if ((DateTime.Now.Year - e.Birthday.Year) > 60)
            {
                ModelState.AddModelError("Birthday", "Employee must not be older than 60 years.");
                ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId", e.DepartmentId);
                ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "NamePosition", e.PositionId);
                return View("AddEmployee", e);
            }
            e.EmployeeId = GenerateId();
            db.Employees.Add(e);
            db.SaveChanges();
            TempData["Success"] = "Add Employee Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult AddEmployee()
        {
            try
            {
                ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId");
                ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "NamePosition");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error" + ex.Message;
            }
            return View();
        }

        private string GenerateId()
        {
            var lastEmployee = db.Employees.OrderByDescending(emp => emp.EmployeeId).FirstOrDefault();
            int lastId = lastEmployee != null ? int.Parse(lastEmployee.EmployeeId.Substring(2)) : 0;
            string newId = (lastId + 1).ToString("D3");
            string generatedId = "NV" + newId.Trim();
            return generatedId;
        }

        [HttpGet]
        public IActionResult findEmployee(string id)
        {
            List<Employee> ds = db.Employees.Where(x => x.LastName.Contains(id) || x.EmployeeId == (id) || x.PhoneNumber == (id)).ToList();

            if (ds.Count() == 0)
            {
                TempData["Success"] = "Employee not found.";
            }

            if (ds.Count() == null)
            {
                TempData["Success"] = "Error";
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentId");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NamePosition");
            return PartialView(ds);
        }
       
        public IActionResult formDelete(String id)
        {
            Models.Employee x = db.Employees.Find(id);
            if (x.Status == 1)
            {
                ViewBag.flat = "N-OK";
            }
            TempData["Success"] = "Cann't detele this employees";
            return View(x);
        }

        //public IActionResult deleteEmployee(string employeeId)
        //{
        //    var employee = db.Employees.Find(employeeId);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        if (employee.Status == 0)
        //        {
        //            try
        //            {
        //                var workingDays = db.Works.Where(w => w.EmployeeId == employeeId);
        //                db.Works.RemoveRange(workingDays);
        //                var salaries = db.Salaries.Where(s => s.EmployeeId == employeeId);
        //                db.Salaries.RemoveRange(salaries);
        //                var Detailsalaries = db.DetailSalaries.Where(s => s.EmployeeId == employeeId);
        //                db.DetailSalaries.RemoveRange(Detailsalaries);
        //                throw new("debug");
        //                db.Employees.Remove(employee);
        //                db.SaveChanges();

        //                Transaction.
        //                TempData["Success"] = "Detele Successfully ";
        //                return RedirectToAction("Index", "Employees");
        //            }
        //            catch (Exception ex)
        //            {
        //                return View("Error", ex);
        //            }
        //        }
        //    }   
        //    return RedirectToAction("Index");
        //}




        public IActionResult deleteEmployee(string employeeId)
        {
            var employee = db.Employees.Find(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            if (employee.Status == 0)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // Xóa các bản ghi công việc của nhân viên
                        var workingDays = db.Works.Where(w => w.EmployeeId == employeeId);
                        db.Works.RemoveRange(workingDays);

                        // Xóa các bản ghi lương của nhân viên
                        var salaries = db.Salaries.Where(s => s.EmployeeId == employeeId);
                        db.Salaries.RemoveRange(salaries);

                        // Xóa các bản ghi chi tiết lương của nhân viên
                        var detailSalaries = db.DetailSalaries.Where(ds => ds.EmployeeId == employeeId);
                        db.DetailSalaries.RemoveRange(detailSalaries);
                        throw new("debug");
                        // Xóa bản ghi nhân viên
                        db.Employees.Remove(employee);

                        // Lưu các thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();

                        // Commit transaction
                        transaction.Commit();

                        TempData["Success"] = "Delete Successfully";
                        return RedirectToAction("Index", "Employees");
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi
                        transaction.Rollback();
                        TempData["Error"] = "Error deleting employee: " + ex.Message;
                        return View("Error", ex);
                    }
                }
            }

            TempData["Error"] = "Employee is still active.";
            return RedirectToAction("Index");
        }

        public IActionResult formUpdate(string id)
        {

            Models.Employee x = db.Employees.Find(id);
            ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId");
            ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "NamePosition");
            return View(x);
        }
        [HttpPost]
        public IActionResult updateEmployees(Models.Employee x)
        {

            if (ModelState.IsValid)
            {
                Models.Employee e = db.Employees.Find(x.EmployeeId);
                if (e != null)
                {
                    e.FirstName = x.FirstName;
                    e.MiddleName = x.MiddleName;
                    e.LastName = x.LastName;
                    e.PhoneNumber = x.PhoneNumber;
                    e.DepartmentId = x.DepartmentId;
                    e.Birthday = x.Birthday;
                    if (e.Birthday.Year >= DateTime.Now.Year || (DateTime.Now.Year - e.Birthday.Year) < 18)
                    {
                        ModelState.AddModelError("Birthday", "Employee must be at least 18 years old.");
                        ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId", x.DepartmentId);
                        ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "NamePosition", x.PositionId);
                        return View("formUpdate", x);
                    }
                    e.Gender = x.Gender;
                    e.Address = x.Address;
                    e.PositionId = x.PositionId;
                    e.Position = x.Position;
                    e.Status = x.Status;
                    db.SaveChanges();
                    TempData["Success"] = "Update Successfully ";

                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(db.Departments, "DepartmentId", "DepartmentId", x.DepartmentId);
            ViewData["PositionId"] = new SelectList(db.Positions, "PositionId", "NamePosition", x.PositionId);
            return View("formUpdate",x);
        }
    }
}
