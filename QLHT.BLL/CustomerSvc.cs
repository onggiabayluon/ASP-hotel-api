using System;
using System.Collections.Generic;
using System.Text;
using QLHT.Common.BLL;
using QLHT.Common.Rsp;
using QLHT.DAL;
using QLHT.DAL.Models;
using QLHT.Common.Req;

namespace QLHT.BLL
{
    public class CustomerSvc: GenericSvc<CustomerRep, Customer>
    {
        private CustomerRep customerRep;

        public CustomerSvc()
        {
            customerRep = new CustomerRep();
        }

        public MultipleRsp List()
        {
            var res = new MultipleRsp();
            //res.Data = _rep.List();
            return res;
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }


        public SingleRsp CreateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            Customer cus = new Customer();
            cus.Address = customerReq.Address;
            cus.Name = customerReq.Name;
            cus.Password = customerReq.Password;
            cus.IdCard = customerReq.IdCard;
            //cus.Phone = customerReq.Phone;
            cus.TypeId = customerReq.TypeId;
            res = customerRep.CreateCustomer(cus);
            return res;
        }

        public SingleRsp UpdateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            Customer cus = new Customer();
            cus.Address = customerReq.Address;
            cus.Name = customerReq.Name;
            cus.IdCard = customerReq.IdCard;
            cus.Password = customerReq.Password;
            //cus.Phone = customerReq.Phone;
            cus.TypeId = customerReq.TypeId;
            res = customerRep.UpdateCustomer(cus);
            return res;
        }

        public SingleRsp DeleteCustomer(int id)
        {
            var res = new SingleRsp();
            res = customerRep.Remove(id);
            return res;
        }

    }
}
