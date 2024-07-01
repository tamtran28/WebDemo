using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class DetailSalaryController : Controller
    {
        private testContext db = new testContext();
        // GET: DetailSalaryController
        public ActionResult SetEmployeeId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Employee ID is required");
            }

            HttpContext.Session.SetString("EmployeeId", id);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var employeeId = HttpContext.Session.GetString("EmployeeId");
            if (string.IsNullOrEmpty(employeeId))
            {
                return BadRequest("Employee ID is required");
            }

            var baseSalaries = db.Positions.ToDictionary(p => p.PositionId, p => p.BaseSalary);

            var detailSalariesWithWorkingDays = db.DetailSalaries
                .Include(ds => ds.Salary)
                    .ThenInclude(s => s.Employee)
                        .ThenInclude(e => e.Works)
                .Where(ds => ds.Salary.EmployeeId == employeeId) // Filter by Employee ID
                .Select(ds => new DetailSalaryView
                {
                    DetailSalaryId = ds.DetailSalaryId,
                    SalaryId = ds.SalaryId,
                    OverTime = ds.Salary.Employee.Works.Sum(m => m.OverTime ?? 0),
                    BaseSalary = baseSalaries.ContainsKey(ds.Salary.Employee.PositionId) ? baseSalaries[ds.Salary.Employee.PositionId] : 0,
                    SocialInsurance = ds.SocialInsurance,
                    HealthInsurance = ds.HealthInsurance,
                    PersonalIncomeTax = ds.PersonalIncomeTax,
                    DateCreate = ds.DateCreate,
                    TotalSalary = ds.TotalSalary,
                    EmployeeId = ds.EmployeeId,
                    EmployeeName = ds.Salary.Employee.LastName + " " + ds.Salary.Employee.MiddleName + " " + ds.Salary.Employee.FirstName,
                    TotalWorkingDays = ds.Salary.Employee.Works.Sum(w => w.TotalWorkingDay ?? 0),
                    ToltalAllowances = ds.Salary.Employee.Works.Sum(w => w.TotalWorkingDay ?? 0) > 0
                        ? db.Allowances.Where(a => a.PositionId == ds.Salary.Employee.PositionId).Sum(a => a.PhoneAllowance + a.OtherAllowance)
                        : 0
                })
                .ToList();

            return View(detailSalariesWithWorkingDays);
        }

        public IActionResult CalculateSalary(string id)
        {
            try
            {
                var workRecords = db.Works
                    .Where(w => w.EmployeeId == id)
                    .ToList();
                var totalDay = workRecords.Sum(e => e.TotalWorkingDay);

                ViewBag.TotalSalary = totalDay;
                var totalHours = workRecords.Sum(w => w.TotalHourWorking ?? 0);
                var totalOverTime = workRecords.Sum(w => w.OverTime ?? 0);
                if (totalDay == 0)
                {
                    TempData["alert"] = "The employee did not work this month.";
                    return RedirectToAction("Index", "Salary");
                }

                var employee = db.Employees
                    .Include(e => e.Position)
                    .FirstOrDefault(e => e.EmployeeId == id);
                var allowances = 0m;
                if (employee != null)
                {
                    allowances = db.Allowances
                                  .Include(a => a.Position)
                                  .ThenInclude(p => p.Employees)
                                  .Where(a => a.Position.PositionId == employee.PositionId).Sum(a => a.PhoneAllowance + a.OtherAllowance);
                }
                if (employee == null)
                {
                    return NotFound();
                }

                var baseSalary = employee.Position.BaseSalary;
                var salaryPerDay = baseSalary / 22;
                var salaryPerHour = baseSalary / 176;

                var totalSalary = (int)totalDay * (decimal)salaryPerDay + totalOverTime * (salaryPerHour * 1.5m);

                var socialInsurance = totalSalary * 0.08m;
                var healthInsurance = totalSalary * 0.015m;
                var personalIncomeTax = totalSalary * 0.01m;

                if (employee.Status == 0)
                {
                    TempData["alert"] = "The employee has resigned";
                    return RedirectToAction("Index", "Salary");
                }
                var existingDetailSalary = db.DetailSalaries
                    .Include(ds => ds.Salary)
                    .FirstOrDefault(ds => ds.Salary.EmployeeId == id && ds.DateCreate.Month == DateTime.Now.Month && ds.DateCreate.Year == DateTime.Now.Year);

                if (existingDetailSalary != null)
                {
                    TempData["alert"] = "Salary already exists for the current month.";
                    return RedirectToAction("Index", "Salary");
                }

                var salary = new Salary
                {
                    EmployeeId = id,
                    DateRecieved = DateTime.Now,
                    TotalWorkingDay = (int)totalDay
                };
                db.Salaries.Add(salary);
                db.SaveChanges();

                var detailSalary = new DetailSalary
                {
                    SalaryId = salary.SalaryId,
                    SocialInsurance = socialInsurance,
                    HealthInsurance = healthInsurance,
                    PersonalIncomeTax = personalIncomeTax,
                    DateCreate = DateTime.Now,
                    TotalSalary = totalSalary - (socialInsurance + healthInsurance + personalIncomeTax) + allowances,
                    EmployeeId = id
                };
                db.DetailSalaries.Add(detailSalary);
                TempData["alert"] = "Successfully";
                db.SaveChanges();

                ViewBag.Salary = totalSalary;
                return RedirectToAction("Index", "DetailSalary");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
