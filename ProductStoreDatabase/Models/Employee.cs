using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}