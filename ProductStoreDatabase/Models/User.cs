using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }


    }
}