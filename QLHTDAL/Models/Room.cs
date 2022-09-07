using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            Receipts = new HashSet<Receipt>();
            Registrations = new HashSet<Registration>();
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public string Image { get; set; }
        public short? Active { get; set; }
        public int? Quantity { get; set; }
        public int CategoryId { get; set; }

        public virtual RoomType Category { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
