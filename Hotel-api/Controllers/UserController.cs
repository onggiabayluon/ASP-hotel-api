using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHT.BLL;
using QLHT.Common.Req;
using QLHT.Common.Rsp;
using QLHT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController() 
        {
            userSvc = new UserSvc();
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var res = new SingleRsp();
            res = userSvc.Read(id);
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult CreatUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }


        [HttpDelete("delete-user/{id}")]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var res = userSvc.DeleteUser(id);
            return Ok(res);
        }

    }
}
