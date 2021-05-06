using ProductStoreDB.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
    public class Role
    {

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    
    }
}
