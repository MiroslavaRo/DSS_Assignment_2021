using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
    public class Employee
    {
        public Employee()
        {
            Users = new HashSet<User>();
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Speecialization { get; set; }
        public int? RoleId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    
    }
}
