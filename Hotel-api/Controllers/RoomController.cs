using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHT.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private RoomSvc roomSvc;
        public RoomController()
        {
            roomSvc = new RoomSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult GetRoomById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = roomSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("create")]
        public IActionResult CreateRoom([FromBody] RoomReq roomReq)
        {
            // Custom lại roomReq để giao diện chỉ cho thêm một số cột của Room Model
            // chứ không cho thêm hết
            var res = new SingleRsp();
            res = roomSvc.CreateRoom(roomReq);
            return Ok(res);
        }

        [HttpPost("update-room")]
        public IActionResult UpdateRoom([FromBody] RoomReq reqRoom)
        {
            var res = roomSvc.UpdateRoom(reqRoom);
            return Ok(res);
        }
    }
}
