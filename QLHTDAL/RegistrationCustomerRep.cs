using QLHT.Common.DAL;
using QLHT.Common.Rsp;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLHT.DAL
{
    public class RegistrationCustomerRep : GenericRep<hotelappSQLContext, CustomerRegistration>
    {
        public RegistrationCustomerRep()
        {

        }
        public override CustomerRegistration Read(int id)
        {
            var re = All.FirstOrDefault(r => r.RegistrationId == id);
            return re;
        }

        public SingleRsp Create(CustomerRegistration re)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using var tran = context.Database.BeginTransaction();

                try
                {
                    var p = context.CustomerRegistrations.Add(re);
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

        public SingleRsp Update(CustomerRegistration re)
        {
            var res = new SingleRsp();
            using (var context = new hotelappSQLContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.CustomerRegistrations.Update(re);
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
