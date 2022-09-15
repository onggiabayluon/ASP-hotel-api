using QLHT.Common.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;
using QLHT.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLHT.BLL
{
    public class RegistrationRoomSvc : GenericSvc<RegistrationRoomRep, Registration>
    {
        private RegistrationRoomRep registrationRoomRep;
        
        public RegistrationRoomSvc()
        {
            registrationRoomRep = new RegistrationRoomRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp DeleteRoom(int id)
        {
            var res = new SingleRsp();
            res = registrationRoomRep.Remove(id);
            return res;
        }

        public SingleRsp CreateRoom(RegistrationReq reReq)
        {
            var res = new SingleRsp();
            Registration re = new Registration();
            //room.Id = roomReq.Id;
            re.CheckInTime = reReq.CheckInTime;
            re.CheckOutTime = reReq.CheckOutTime;
            re.RoomId = reReq.RoomId;

            res = registrationRoomRep.CreateRoom(re);
            return res;
        }

        public SingleRsp UpdateRoom(RegistrationReq reReq)
        {
            var res = new SingleRsp();
            Registration re = new Registration();
            re.Id = reReq.Id;
            re.CheckInTime = reReq.CheckInTime;
            re.CheckOutTime = reReq.CheckOutTime;
            re.RoomId = reReq.RoomId;

            res = registrationRoomRep.UpdateRoom(re);
            return res;
        }
    }
}
