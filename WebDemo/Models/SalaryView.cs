using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class SalaryView
    {
       
       
            public int SalaryId { get; set; }
            public int TotalWorkingDay { get; set; }
            public string EmployeeId { get; set; }
            public DateTime? DateRecieved { get; set; }
            public string EmployeeName { get; set; }
            public decimal TotalSalary { get; set; }


    }
}
