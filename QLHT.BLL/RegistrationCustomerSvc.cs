using QLHT.Common.BLL;
using QLHT.DAL.Models;
using QLHT.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using QLHT.Common.Req;
using QLHT.Common.Rsp;

namespace QLHT.BLL
{
    public class RegistrationCustomerSvc : GenericSvc<RegistrationCustomerRep, CustomerRegistration>
    {
        private RegistrationCustomerRep registrationCustomerRep;

        public RegistrationCustomerSvc()
        {
            registrationCustomerRep = new RegistrationCustomerRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateRoom(RegistrationCustomerReq reReq)
        {
            var res = new SingleRsp();
            CustomerRegistration re = new CustomerRegistration();
            re.RegistrationId = reReq.RegistrationId;
            re.CustomerId = reReq.CustomerId;

            res = registrationCustomerRep.Create(re);
            return res;
        }

        public SingleRsp UpdateRoom(RegistrationCustomerReq reReq)
        {
            var res = new SingleRsp();
            CustomerRegistration re = new CustomerRegistration();
            re.RegistrationId = reReq.RegistrationId;
            re.CustomerId = reReq.CustomerId;

            res = registrationCustomerRep.Update(re);
            return res;
        }
    }
}
