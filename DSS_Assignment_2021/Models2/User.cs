using System;
using System.Collections.Generic;

#nullable disable

namespace DSS_Assignment_2021.Models2
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
