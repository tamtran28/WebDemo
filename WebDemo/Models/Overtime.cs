using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Overtime
    {
        public int OvertimeId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeRate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
