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
    public class ReservationSvc : GenericSvc<ReservationRep, Reservation>
    {
        private ReservationRep reservationRep;
        public ReservationSvc()
        {
            reservationRep = new ReservationRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateReservation(ReservationReq reservationReq)
        {
            var res = new SingleRsp();
            Reservation reservation = new Reservation();
            //reservation.Id = reservationReq.Id;
            reservation.Name = reservationReq.Name;
            reservation.Price = reservationReq.Price;
            reservation.Description = reservationReq.Description;
            reservation.Quantity = reservationReq.Quantity;

            res = reservationRep.CreateReservation(reservation);
            return res;
        }

        public SingleRsp UpdateReservation(ReservationReq reservationReq)
        {
            var res = new SingleRsp();
            Reservation reservation = new Reservation();
            reservation.Name = reservationReq.Name;
            reservation.Price = reservationReq.Price;
            reservation.Description = reservationReq.Description;
            reservation.Quantity = reservationReq.Quantity;

            res = reservationRep.UpdateReservation(reservation);
            return res;
        }


        public SingleRsp DeleteReservation(int id)
        {
            var res = new SingleRsp();
            res = reservationRep.Remove(id);
            return res;
        }
    }
}
