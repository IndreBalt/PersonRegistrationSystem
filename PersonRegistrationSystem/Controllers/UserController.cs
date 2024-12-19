using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.DataBase.Repositories;
using PersonRegistrationSystem.Dtos.RequestsDtos;
using PersonRegistrationSystem.Mappers;
using PersonRegistrationSystem.Services;

namespace PersonRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUserService _userService;
        private readonly IPersonalInfoMapper _personalInfoMapper;
        private readonly IJwtService _jwtService;

        public UserController(IJwtService jwtService, IUserRepository userRepository, IUserMapper userMapper, IUserService userService, IPersonalInfoMapper personalInfoMapper)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
            _userService = userService;
            _personalInfoMapper = personalInfoMapper;
            _jwtService = jwtService;

        }

        [HttpPost("Registration")]
        public IActionResult CreateUser([FromForm] UserRequestDto user)
        {
            if (_userRepository.GetUserByUserName(user.UserName) is not null)
            {
                return Conflict("User already exists");
            }
            User newUser = _userMapper.Map(user);
            var userId = _userRepository.CreateUser(newUser);
            return Created("", new { id = userId });
        }


        [HttpGet("LogIn")]
        public IActionResult LogIn([FromQuery] string username, string password)
        {
            var user = _userService.LogIn(username, password);
            if (user is null)
            {
                return BadRequest("Bad username or password");
            }
            string token = _jwtService.JwtToken(user);
            return Ok(token);
        }

        [HttpGet("GetUserByUserName")]
        public IActionResult GetUserByUserName(string userName)
        {
            var user = _userRepository.GetUserByUserName(userName);
            if (user is not null)
            {
                var result = _userMapper.Map(user);
                return Ok(result);
            }
            return NotFound();
        }


        [Authorize(Roles = "User")]
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if(user is not null)
            {
                var result = _userMapper.Map(user);
                return Ok(result);
            }
            return NotFound();
        }

        [Authorize]        
        [HttpGet("GetPhotoById")]
        public IActionResult GetUserPhotoById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if (user is not null)
            {
                var img = File(user.PersonalInfo.ProfilePhoto, "image/jpeg");
                return img;
            }
            return NotFound();
        }

       
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUSer([FromRoute]Guid id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();

        }
        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers() 
        {
            var users = _userRepository.GetUsers();
            if(users is not null)
            {
                var result = _userMapper.Map(users);
                return Ok(result);
            }
            return NoContent();
        }
     


        
    }
}
