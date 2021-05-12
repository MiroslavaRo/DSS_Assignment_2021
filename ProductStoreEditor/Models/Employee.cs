using System;
using System.Collections.Generic;

#nullable disable

namespace ProductStoreEditor.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Users = new HashSet<User>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
