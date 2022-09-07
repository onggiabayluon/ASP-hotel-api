using System;
using System.Collections.Generic;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class CustomerRegistration
    {
        public int RegistrationId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
