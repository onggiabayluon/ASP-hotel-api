using QLHT.Common.BLL;
using QLHT.Common.Rsp;
using QLHT.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.BLL
{
    public class RoomSvc : GenericSvc<RoomRep, Room>
    {
        private RoomRep roomRep;
        public RoomSvc()
        {
            roomRep = new RoomRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
    }
}
