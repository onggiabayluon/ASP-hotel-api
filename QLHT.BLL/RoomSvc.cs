using QLHT.Common.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;
using QLHT.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public SingleRsp CreateRoom(RoomReq roomReq)
        {
            var res = new SingleRsp();
            Room room = new Room();
            //room.Id = roomReq.Id;
            room.Name = roomReq.Name;
            room.Price = roomReq.Price;
            room.Description = roomReq.Description;
            room.Quantity = roomReq.Quantity;

            res = roomRep.CreateRoom(room);
            return res;
        }

        public SingleRsp UpdateRoom(RoomReq roomReq)
        {
            var res = new SingleRsp();
            Room room = new Room();
            room.Name = roomReq.Name;
            room.Price = roomReq.Price;
            room.Description = roomReq.Description;
            room.Quantity = roomReq.Quantity;

            res = roomRep.UpdateRoom(room);
            return res;
        }


        public SingleRsp DeleteRoom(int id)
        {
            var res = new SingleRsp();
            res = roomRep.Remove(id);
            return res;
        }
    }
}
