using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class Surcharge
    {
        public Surcharge()
        {
            ReceiptSurcharges = new HashSet<ReceiptSurcharge>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public float? Ratio { get; set; }

        public virtual ICollection<ReceiptSurcharge> ReceiptSurcharges { get; set; }
    }
}
