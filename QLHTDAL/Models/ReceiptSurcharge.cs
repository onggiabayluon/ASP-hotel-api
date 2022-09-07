using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class ReceiptSurcharge
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int SurchargeId { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual Surcharge Surcharge { get; set; }
    }
}
