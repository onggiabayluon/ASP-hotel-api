using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.Common.Req
{
    public class CustomerReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        //public decimal? Phone { get; set; }
        public string IdCard { get; set; }
        public string Address { get; set; }
        public int? TypeId { get; set; }
    }
}
