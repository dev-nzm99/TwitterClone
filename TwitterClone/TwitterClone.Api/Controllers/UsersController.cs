using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
           _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUsers([FromBody] CreateUserDto createUserDto)
        {
            var createdUser = _userService.CreateUser(createUserDto);

            if(createdUser == null)
            {
                return BadRequest("A error happen during create user.");
            }

            return Ok(createdUser);
        }

        //GET api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        //PUT api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpadateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userService.UpdateUser(id, updateUserDto);

            if (user == null) {
                return NotFound();
            }

            return Ok(user);
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
            
            var isDeleted = _userService.DeleteUser(id);

            if(isDeleted != true)
            {
                return NotFound();
            }

            return Ok(isDeleted);
        }
    }
}
