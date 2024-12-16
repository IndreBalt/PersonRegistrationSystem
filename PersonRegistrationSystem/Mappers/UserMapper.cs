using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.Dtos.RequestsDtos;
using PersonRegistrationSystem.Dtos.ResponceDtos;
using PersonRegistrationSystem.Services;

namespace PersonRegistrationSystem.Mappers
{
    public interface IUserMapper
    {
        User Map(UserRequestDto req);
        UserResponceDto Map(User user);
        List<UserResponceDto> Map(List<User> users);
    }
    public class UserMapper: IUserMapper
    {
        private readonly IUserService _userService;
        private readonly IPersonalInfoMapper _personalInfoMapper;
        public UserMapper(IUserService userService, IPersonalInfoMapper personalInfoMapper)
        {
            _userService = userService;
            _personalInfoMapper = personalInfoMapper;
        }
        public User Map(UserRequestDto req)
        {
           _userService.CreatePasswordHash(req.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                UserName = req.UserName,
                Password = passwordHash,
                Salt = passwordSalt,
                Role = "User",
                PersonalInfo = _personalInfoMapper.Map(req.PersonalInfo)
            };
        }
        public UserResponceDto Map(User user) 
        {
            return new UserResponceDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                PersonalInfo = new PersonalInfoResponceDto
                {
                    FirstName = user.PersonalInfo.FirstName,
                    LastName = user.PersonalInfo.LastName,
                    PersonalId = user.PersonalInfo.PersonalId,
                    Email = user.PersonalInfo.Email,
                    PhoneNumber = user.PersonalInfo.PhoneNumber,
                    //ProfilePhoto = user.PersonalInfo.ProfilePhoto,
                    Address = new LivingAddressDto()
                    {
                        City = user.PersonalInfo.Address.City,
                        Street = user.PersonalInfo.Address.Street,
                        HouseNumber = user.PersonalInfo.Address.HouseNumber,
                        ApartmentNumber = user.PersonalInfo.Address.ApartmentNumber,
                    }
                }
            };
        }
        public List<UserResponceDto> Map(List<User> users) 
        {
            return users.Select(u =>Map(u)).ToList();
        }


    }

    
}
