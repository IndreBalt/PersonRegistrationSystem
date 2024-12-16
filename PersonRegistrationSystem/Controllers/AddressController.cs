using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonRegistrationSystem.DataBase.Repositories;
using System.IO;
using System.Security.Claims;

namespace PersonRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AddressController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateCity")]
        public IActionResult UpdateCity(Guid userId, string city)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                if (tokenId == userId.ToString())
                {
                    var user = _userRepository.GetUserById(userId);
                    user.PersonalInfo.Address.City = city;
                    _userRepository.UpdateUser(user);
                    return Ok(user.PersonalInfo.Address.City);
                }
            }
            return Forbid();

        }


        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateStreet")]
        public IActionResult UpdateStreet(Guid userId, string street)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                if (tokenId == userId.ToString())
                {
                    var user = _userRepository.GetUserById(userId);
                    user.PersonalInfo.Address.Street = street;
                    _userRepository.UpdateUser(user);
                    return Ok(user.PersonalInfo.Address.Street);
                }
            }
            return Forbid();
        }


        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateHouseNumber")]
        public IActionResult UpdateHouseNumber(Guid userId, int houseNumber)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                if (tokenId == userId.ToString())
                {
                    var user = _userRepository.GetUserById(userId);
                    user.PersonalInfo.Address.HouseNumber = houseNumber;
                    _userRepository.UpdateUser(user);
                    return Ok(user.PersonalInfo.Address.HouseNumber);
                }
            }
            return Forbid();
        }


        [Authorize(Roles = "User")]
        [HttpPut("{userId:guid}/UpdateApartmentNumber")]
        public IActionResult UpdateApartmentNumber(Guid userId, int apartmentNumber)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var tokenId = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                if (tokenId == userId.ToString())
                {
                    var user = _userRepository.GetUserById(userId);
                    user.PersonalInfo.Address.ApartmentNumber = apartmentNumber;
                    _userRepository.UpdateUser(user);
                    return Ok(user.PersonalInfo.Address.ApartmentNumber);
                }
            }
            return Forbid();
        }
    }
}
