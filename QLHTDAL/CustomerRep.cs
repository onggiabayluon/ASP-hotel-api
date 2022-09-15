using QLHT.Common.DAL;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLHT.Common.Rsp;

namespace QLHT.DAL
{
    public class CustomerRep : GenericRep<hotelappSQLContext, Customer>
    {
        public CustomerRep()
        {

        }

        public Customer List()
        {
            var p = All.Select(r => r);

            return (Customer)p;
        }

        public override Customer Read(int id)
        {
            var res = All.FirstOrDefault(r => r.Id == id);
            return res;
        }


        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.Customers.Remove(Read(id));
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


        public SingleRsp CreateCustomer(Customer cus)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();
                try
                {
                    var c = context.Customers.Add(cus);
                    context.SaveChanges();
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            return res;
        }

        public SingleRsp UpdateCustomer(Customer cus)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();
                try
                {
                    var c = context.Customers.Update(cus);
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

        public SingleRsp DeleteCustomer(Customer cus)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();
                try
                {
                    var c = context.Customers.Remove(cus);
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
    }
}
