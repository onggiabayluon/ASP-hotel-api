using QLHT.Common.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLHT.Common.Rsp;

namespace QLHT.DAL
{
    public class ReservationRep : GenericRep<hotelappSQLContext, Reservation>
    {
        public ReservationRep()
        {

        }
        public override Reservation Read(int id)
        {
            var reservation = All.FirstOrDefault(r => r.Id == id);
            return reservation;
        }

        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Reservations.Remove(Read(id));
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

        public SingleRsp CreateReservation(Reservation reservation)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Reservations.Add(reservation);
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

        public SingleRsp UpdateReservation(Reservation reservation)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Reservations.Update(reservation);
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
