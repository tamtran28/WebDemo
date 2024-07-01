using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Position
    {
        public Position()
        {
            Allowances = new HashSet<Allowance>();
            DepartmentPositions = new HashSet<DepartmentPosition>();
            Employees = new HashSet<Employee>();
        }

        public string PositionId { get; set; }
        public string NamePosition { get; set; }
        public decimal BaseSalary { get; set; }

        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
