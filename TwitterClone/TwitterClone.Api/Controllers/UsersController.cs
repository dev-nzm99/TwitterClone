using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TwitterClone.Api.Data;
using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository) 
        {
           _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUsers([FromBody] CreateUserDto createUserDto )
        {

            if(string.IsNullOrWhiteSpace(createUserDto.Firstname)||
               string.IsNullOrWhiteSpace(createUserDto.Lastname)||
               string.IsNullOrWhiteSpace(createUserDto.Email)
              )
            {
                return BadRequest("All fields are required.");
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);

            if(existingUser  != null )
            {
                return Conflict("A user with this email already exists.");
            }

            var createUser = _userRepository.AddUser(new User
            {
                FirstName = createUserDto.Firstname,
                LastName = createUserDto.Lastname,
                Email = createUserDto.Email,
            });

            return Ok(createUser);
        }

        //GET api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);
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
            var user = _userRepository.GetUserById(id);
           
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updateUserDto.Firstname;
            user.LastName = updateUserDto.Lastname;

            _userRepository.UpdateUser(user);
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
            var user = _userRepository.GetUserById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var isDeleted = _userRepository.DeleteUser(user);
            
            return Ok(isDeleted);   
        }
    }
}
