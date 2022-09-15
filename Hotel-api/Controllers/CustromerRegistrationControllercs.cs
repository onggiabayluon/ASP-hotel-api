using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHT.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustromerRegistrationControllercs : ControllerBase
    {
        private RegistrationCustomerSvc registrationCustomerSvc;
        public CustromerRegistrationControllercs()
        {
            registrationCustomerSvc = new RegistrationCustomerSvc();
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetRoomById([FromRoute] int id)
        {
            var res = new SingleRsp();
            res = registrationCustomerSvc.Read(id);
            return Ok(res);
        }

        [HttpPost("create-registration-customer")]
        public IActionResult CreateRoom([FromBody] RegistrationCustomerReq reReq)
        {
            // Custom lại roomReq để giao diện chỉ cho thêm một số cột của Room Model
            // chứ không cho thêm hết
            var res = new SingleRsp();
            res = registrationCustomerSvc.CreateRoom(reReq);
            return Ok(res);
        }

        [HttpPatch("update-registration-customer")]
        public IActionResult UpdateRoom([FromBody] RegistrationCustomerReq reReq)
        {
            var res = registrationCustomerSvc.UpdateRoom(reReq);
            return Ok(res);
        }
    }
}
