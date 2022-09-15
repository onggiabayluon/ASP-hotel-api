using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.Common.Req
{
    public class RegistrationReq
    {
        public int Id { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int RoomId { get; set; }
    }
}
