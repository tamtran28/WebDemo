using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class DetailSalary
    {
        public int DetailSalaryId { get; set; }
        public int SalaryId { get; set; }
        public decimal SocialInsurance { get; set; }
        public decimal HealthInsurance { get; set; }
        public decimal PersonalIncomeTax { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal TotalSalary { get; set; }
        public string EmployeeId { get; set; }

        public virtual Salary Salary { get; set; }
    }
}
