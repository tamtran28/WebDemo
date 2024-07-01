using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class DepartmentPosition
    {
        public string DepartmentId { get; set; }
        public string PositionId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
    }
}
