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
    public class UserSvc : GenericSvc <UserRep, User>
    {
        private UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.Name = userReq.Name;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.UserRole = userReq.UserRole;
            //user.Active = (short)(userReq.Active);
            //user.JoinedDate = new DateTime();
            user.Email = userReq.Email;
            res = userRep.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.Id = userReq.Id;
            user.Name = userReq.Name;
            user.Username = userReq.Username;
            user.Password = userReq.Password;
            user.UserRole = userReq.UserRole;
            //user.Active = (short)(userReq.Active);
            //user.JoinedDate = new DateTime();
            user.Email = userReq.Email;
            res = userRep.UpdateUser(user);
            return res;
        }

        public override SingleRsp Update(User u)
        {
            var res = new SingleRsp();

            var m1 = _rep.Read(u.Id);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(u);
                res.Data = u;
            }

            return res;
        }

    }
}
