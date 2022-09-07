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
        public IActionResult getRoomById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = roomSvc.Read(req.Id);
            return Ok(res);
        }
    }
}
