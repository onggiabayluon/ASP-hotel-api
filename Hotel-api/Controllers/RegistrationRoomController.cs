using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHT.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationRoomController : ControllerBase
    {
        private RegistrationRoomSvc registrationRoomSvc;
        public RegistrationRoomController()
        {
            registrationRoomSvc = new RegistrationRoomSvc();
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetRoomById([FromRoute] int id)
        {
            var res = new SingleRsp();
            res = registrationRoomSvc.Read(id);
            return Ok(res);
        }

        [HttpDelete("delete-registration/{id}")]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var res = registrationRoomSvc.DeleteRoom(id);
            return Ok(res);
        }
        [HttpPost("create-registration")]
        public IActionResult CreateRoom([FromBody] RegistrationReq reReq)
        {
            // Custom lại roomReq để giao diện chỉ cho thêm một số cột của Room Model
            // chứ không cho thêm hết
            var res = new SingleRsp();
            res = registrationRoomSvc.CreateRoom(reReq);
            return Ok(res);
        }

        [HttpPatch("update-room")]
        public IActionResult UpdateRoom([FromBody] RegistrationReq reReq)
        {
            var res = registrationRoomSvc.UpdateRoom(reReq);
            return Ok(res);
        }
    }
}
