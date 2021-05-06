using System;
using System.Collections.Generic;

#nullable disable

namespace DSS_Assignment_2021.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Users = new HashSet<User>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Speecialization { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
