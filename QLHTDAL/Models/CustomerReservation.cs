using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class CustomerReservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
