using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.Common.Req
{
    public class RoomReq
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        //public string Image { get; set; }
        //public short? Active { get; set; }
        public int? Quantity { get; set; }
        //public int CategoryId { get; set; }

    }
}
