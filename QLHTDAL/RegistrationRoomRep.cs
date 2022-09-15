using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLHT.Common.DAL;
using QLHT.Common.Rsp;

namespace QLHT.DAL
{
    public class RegistrationRoomRep : GenericRep<hotelappSQLContext, Registration>
    {
        public RegistrationRoomRep()
        {

        }
        public override Registration Read(int id)
        {
            var re = All.FirstOrDefault(r => r.Id == id);
            return re;
        }

        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Registrations.Remove(Read(id));
                    context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            return res;
        }

        public SingleRsp CreateRoom(Registration re)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Registrations.Add(re);
                    context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            return res;
        }

        public SingleRsp UpdateRoom(Registration re)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Registrations.Update(re);
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
    }
}
