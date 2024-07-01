using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Work
    {
        public string EmployeeId { get; set; }
        public int WorkingDayId { get; set; }
        public string TimeStar { get; set; }
        public string TimeEnd { get; set; }
        public int? TotalWorkingDay { get; set; }
        public int? OverTime { get; set; }
        public int? TotalHourWorking { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual WorkingDay WorkingDay { get; set; }
    }
}
