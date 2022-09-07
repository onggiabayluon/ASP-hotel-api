using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            CustomerReservations = new HashSet<CustomerReservation>();
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string ReserveBy { get; set; }
        public string Phone { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<CustomerReservation> CustomerReservations { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
