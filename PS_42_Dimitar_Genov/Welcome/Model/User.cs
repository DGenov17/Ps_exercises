﻿using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public UserRolesEnum Role { get; set; }
        public DateTime? Expires { get; set; }
    }
}
