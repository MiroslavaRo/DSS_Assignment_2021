﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProductStoreDatabase.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
