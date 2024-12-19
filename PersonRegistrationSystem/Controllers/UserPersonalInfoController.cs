using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonRegistrationSystem.DataBase.Repositories;
using PersonRegistrationSystem.Services;
using System.Security.Claims;

namespace PersonRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPersonalInfoController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhotoService _photoService;

        public UserPersonalInfoController(IUserRepository userRepository, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _photoService = photoService;
        }

        [HttpPut("{userId:guid}/UpdateFirstName")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateFirstName(Guid userId, string firstName)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {

                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.FirstName = firstName;
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.FirstName);
                        }
                    }
                }
            }
            return Forbid();

        }


        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateLastName")]
        public IActionResult UpdateLastName(Guid userId, string lastName)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {

                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.LastName = lastName;
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.LastName);
                        }
                    }
                }
            }
            return Forbid();
        }


        [Authorize(Roles = "User")]       
        [HttpPut("{userId:guid}/UpdatePersonalId")]
        public IActionResult UpdatePersonalId(Guid userId, long personalId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {

                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.PersonalId = personalId;
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.PersonalId);
                        }
                    }
                }
            }
            return Forbid();
        }

        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdatePhoneNumber")]
        public IActionResult UpdateUsersPhoneNumber(Guid userId, string phoneNumber)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {
                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.PhoneNumber = phoneNumber;
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.PhoneNumber);
                        }
                    }
                }
            }
            return Forbid();
        }

        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateEmail")]
        public IActionResult UpdateUsersEmail(Guid userId, string email)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {

                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.Email = email;
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.Email);
                        }
                    }
                }
            }
            return Forbid();
        }

        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateProfiePhoto")]

        public IActionResult UpdateUsersProfilePhoto( Guid userId, IFormFile userPhoto)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity is not null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (tokenId is not null)
                {

                    if (tokenId.Value == userId.ToString())
                    {
                        var user = _userRepository.GetUserById(userId);
                        if (user is not null)
                        {
                            user.PersonalInfo.ProfilePhoto = _photoService.PhotoToBytes(userPhoto);
                            _userRepository.UpdateUser(user);
                            return Ok(user.PersonalInfo.ProfilePhoto);
                        }
                    }
                }
            }
            return Forbid();
        }
    }
}
