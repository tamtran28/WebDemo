using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentPositions = new HashSet<DepartmentPosition>();
        }

        public string DepartmentId { get; set; }
        public string NameDepartment { get; set; }
        public int DepartmentManagerId { get; set; }

        public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; }
    }
}
