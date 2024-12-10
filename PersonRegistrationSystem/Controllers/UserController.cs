using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            User newUser = _userMapper.Map(user);
            var userId = _userRepository.CreateUser(newUser);
            return Created("", new {id = userId});
        }
        [HttpGet("LogIn")]
        public IActionResult LogIn([FromQuery]string username, string password)
        {          
            User user = _userService.LogIn(username, password);
            if (user is null)
            {
                return BadRequest("Bad username or password");
            }
            string token = _jwtService.JwtToken(user);
            return Ok(token);
        }
        [HttpGet("GetUserByUserName")]
        public IActionResult GetUserByUserName(string userName, string password)
        {
            var user = _userService.LogIn(userName, password);
            var result = _userMapper.Map(user);
            return Ok(result);
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            var result = _userMapper.Map(user);
            return Ok(result);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User", Policy = "userId")]
        [HttpGet("GetPhotoById")]
        public IActionResult GetUserPhotoById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            var img = File(user.PersonalInfo.ProfilePhoto, "image/jpeg");           
            return img;
        }
        
        
        [HttpPut("{id:guid}/AddPersonalInfo")]
        public IActionResult AddUserPersonalInfo(Guid id,[FromForm] PersonalInfoRequestDto personalInfo)
        {
            var user = _userRepository.GetUserById(id);
            var personInfo = _personalInfoMapper.Map(personalInfo);
            user.PersonalInfo = personInfo;
            _userRepository.UpdateUser(user);
            return Ok(user);                        
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUSer(Guid id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();

        }

        
    }
}
