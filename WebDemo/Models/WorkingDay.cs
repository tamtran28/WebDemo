using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class WorkingDay
    {
        public WorkingDay()
        {
            Works = new HashSet<Work>();
        }

        public int WorkingDayId { get; set; }
        public DateTime DateWork { get; set; }
        public string Describe { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
