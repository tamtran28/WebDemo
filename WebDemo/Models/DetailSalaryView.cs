using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class DetailSalaryView
    {
        public int DetailSalaryId { get; set; }
        public int SalaryId { get; set; }
        public decimal NetSalary { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal SocialInsurance { get; set; }
        public decimal HealthInsurance { get; set; }
        public decimal PersonalIncomeTax { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal TotalSalary { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int OverTime { get; set; }
        public int TotalWorkingDays { get; set; }

        public decimal ToltalAllowances { get; set; }

    }
}
