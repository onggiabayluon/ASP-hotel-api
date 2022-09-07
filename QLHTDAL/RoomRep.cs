using QLHT.Common.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QLHT.DAL
{
    public class RoomRep : GenericRep<hotelappSQLContext, Room>
    {
        public RoomRep()
        {

        }
        public override Room Read(int id)
        {
            var room = All.FirstOrDefault(r => r.Id == id);
            return room;
        }
    }
}
