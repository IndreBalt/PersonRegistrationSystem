using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.DataBase.Repositories;
using System.Security.Cryptography;

namespace PersonRegistrationSystem.Services
{
    public interface IUserService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        User? LogIn(string userName, string password);
        bool VeryfiPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);


    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

     
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }
        public bool VeryfiPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
        public User? LogIn(string userName, string password) 
        {
            var user = _userRepository.GetUserByUserName(userName);
            if (user == null) 
            {
                return null;
            }
            if (VeryfiPasswordHash(password, user.Password, user.Salt)) 
            {
                return user;
            }
            return null;
        }
        

    }

    
}
