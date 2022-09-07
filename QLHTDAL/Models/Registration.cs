using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Registration
    {
        public Registration()
        {
            CustomerRegistrations = new HashSet<CustomerRegistration>();
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<CustomerRegistration> CustomerRegistrations { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
