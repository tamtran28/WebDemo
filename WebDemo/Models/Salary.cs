using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Salary
    {
        public Salary()
        {
            DetailSalaries = new HashSet<DetailSalary>();
        }

        public int SalaryId { get; set; }
        public int TotalWorkingDay { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? DateRecieved { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<DetailSalary> DetailSalaries { get; set; }
    }
}
