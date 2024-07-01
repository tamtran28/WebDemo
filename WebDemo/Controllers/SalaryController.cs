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
    public class SalaryController : Controller
    {
        private testContext db = new testContext();
        // GET: SalaryController
        //public ActionResult Index()
        //{
        //    var baseSalaries = db.Positions.ToDictionary(p => p.PositionId, p => p.BaseSalary);
        //    var detail = db.DetailSalaries
        //        .Include(ds => ds.Salary)
        //            .ThenInclude(s => s.Employee)
        //                .ThenInclude(e => e.Works)
        //        .Select(ds => new DetailSalaryView
        //        {
        //            DetailSalaryId = ds.DetailSalaryId,
        //            SalaryId = ds.SalaryId,
        //            OverTime = (int)ds.Salary.Employee.Works.Sum(m => m.OverTime),
        //            BaseSalary = baseSalaries.ContainsKey(ds.Salary.Employee.PositionId) ? baseSalaries[ds.Salary.Employee.PositionId] : 0,
        //            SocialInsurance = ds.SocialInsurance,
        //            HealthInsurance = ds.HealthInsurance,
        //            PersonalIncomeTax = ds.PersonalIncomeTax,
        //            DateCreate = ds.DateCreate,
        //            TotalSalary = ds.TotalSalary,
        //            EmployeeId = ds.EmployeeId,
        //            EmployeeName = ds.Salary.Employee.LastName + " " + ds.Salary.Employee.MiddleName + " " + ds.Salary.Employee.FirstName,
        //            TotalWorkingDays = ds.Salary.Employee.Works.Sum(w => w.TotalWorkingDay ?? 0),
        //            ToltalAllowances = db.Allowances
        //                                .Where(a => a.PositionId == ds.Salary.Employee.PositionId)
        //                                .Sum(a => a.PhoneAllowance + a.OtherAllowance)
        //        })
        //        .ToList();

        //    return View(detail);
        //}
        public ActionResult Index()
        {
            var detailSalariesWithWorkingDays = db.Salaries
                .Include(s => s.Employee)
                .Include(s => s.DetailSalaries)
                .Select(s => new SalaryView
                {
                    SalaryId = s.SalaryId,
                    TotalWorkingDay = s.TotalWorkingDay,
                    EmployeeId = s.EmployeeId,
                    DateRecieved = s.DateRecieved,
                    EmployeeName = s.Employee.LastName + " " + s.Employee.MiddleName + " " + s.Employee.FirstName,
                    TotalSalary = s.DetailSalaries.Sum(ds => ds.TotalSalary)
                })
                .ToList();

            return View(detailSalariesWithWorkingDays);
        }
       
    }
}
