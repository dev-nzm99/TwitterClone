using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {

        public UsersController() { }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(
                new List<object>
                {
                    new
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "User-1",
                    },
                    new
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "User-2",
                    },
                    new
                    {
                        UserId = Guid.NewGuid(),
                        UserName = "User-3",
                    }
                }
             );
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUsers()
        {
            return Ok(
                new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "newUser"
                }
            );
        }

        //GET api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok(
                new
                {
                    UserId = id,
                    UserName = "user" + id.ToString(),
                }
            );
        }


        //PUT api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpadateUser([FromRoute] Guid id)
        {
            return Ok(
                new
                {
                    UserId = id,
                    UserName = "user" + id.ToString(),
                }
            );
        }

        //PATCH api/users/{id}/phoneNumber
        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
        {
            return Ok("Hello");
        }


        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id) {
            return Ok(
                new
                {
                    UserId = id,
                    Massage = "User deleted succesfully."
                }   
             );
        }
    }
}
