using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
      
    }
}
