using QLHT.Common.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLHT.Common.Rsp;

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

        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Rooms.Remove(Read(id));
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

        public SingleRsp CreateRoom(Room room)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Rooms.Add(room);
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

        public SingleRsp UpdateRoom(Room room)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Rooms.Update(room);
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
