using QLHT.Common.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLHT.Common.Rsp;

namespace QLHT.DAL
{
    public class UserRep : GenericRep <hotelappSQLContext, User>
    {
        public UserRep()
        {

        }

        #region -- Overrides --
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(u => u.Id == id);
            return res;
        }
        

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return m.Id;
        }
        #endregion

        #region -- Methods --

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var u = context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var u = context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        
        #endregion
    }
}
