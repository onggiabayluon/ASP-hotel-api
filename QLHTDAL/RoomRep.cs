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

        public int Remove(int id)
        {
            var room = base.All.First(i => i.Id == id);
            room = base.Delete(room);
            return room.Id;
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
