using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            ReceiptSurcharges = new HashSet<ReceiptSurcharge>();
        }

        public int Id { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public float? UnitPrice { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public int? ReservationId { get; set; }
        public int? RegistrationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<ReceiptSurcharge> ReceiptSurcharges { get; set; }
    }
}
