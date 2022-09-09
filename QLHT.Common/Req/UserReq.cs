using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.Common.Req
{
    public class UserReq
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public short? Active { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string UserRole { get; set; }
    }
}
