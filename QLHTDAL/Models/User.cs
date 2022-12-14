using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public short? Active { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string UserRole { get; set; }
    }
}
