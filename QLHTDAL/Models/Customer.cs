using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerRegistrations = new HashSet<CustomerRegistration>();
            CustomerReservations = new HashSet<CustomerReservation>();
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        public decimal? Phone { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; }
        public int? TypeId { get; set; }

        public virtual CustomerType Type { get; set; }
        public virtual ICollection<CustomerRegistration> CustomerRegistrations { get; set; }
        public virtual ICollection<CustomerReservation> CustomerReservations { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
