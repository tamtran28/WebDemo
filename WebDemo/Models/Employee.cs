using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebDemo.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Overtimes = new HashSet<Overtime>();
            Salaries = new HashSet<Salary>();
            Works = new HashSet<Work>();
        }



        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name cannot contain special characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name cannot contain special characters.")]
        public string LastName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "MiddleName cannot contain special characters.")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Birthday is required.")]
        // [Range(typeof(DateTime), "1/1/1959", "1/1/2100", ErrorMessage = "Birthday must be between 01/01/1959 and 01/01/2016")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Start Date is required.")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStartWork { get; set; }
        [Required(ErrorMessage = "Position ID is required.")]
        public string PositionId { get; set; }
        [Required(ErrorMessage = "Department ID is required.")]
        public string DepartmentId { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - Birthday.Year;
                return age;
            }
        }
        public string FormattedBirthday
        {
            get { return Birthday.ToString("dd/MM/yyyy"); }
        }
        public string FormattedDateStart
        {
            get { return DateStartWork.ToString("dd/MM/yyyy"); }
        }

        public virtual Position Position { get; set; }
        public virtual ICollection<Overtime> Overtimes { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
