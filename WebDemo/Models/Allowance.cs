using System;
using System.Collections.Generic;

#nullable disable

namespace WebDemo.Models
{
    public partial class Allowance
    {
        public int AllowanceId { get; set; }
        public string PositionId { get; set; }
        public decimal PhoneAllowance { get; set; }
        public decimal OtherAllowance { get; set; }

        public virtual Position Position { get; set; }
    }
}
