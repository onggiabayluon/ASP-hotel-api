using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLHT.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private CustomerSvc customerSvc;
        public CustomerController(){
            customerSvc = new CustomerSvc();
        }

        [HttpGet("get-customer-by-id/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var res = new SingleRsp();
            res = customerSvc.Read(id);
            if (res == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(res);
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] CustomerReq customerReq)
        {
            var res = new SingleRsp();
            res = customerSvc.CreateCustomer(customerReq);
            return Ok(res);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CustomerReq customerReq)
        {
            var res = new SingleRsp();
            res = customerSvc.UpdateCustomer(customerReq);
            return Ok(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = new SingleRsp();
            res = customerSvc.DeleteCustomer(id);
            return Ok(res);
        }
    }

}