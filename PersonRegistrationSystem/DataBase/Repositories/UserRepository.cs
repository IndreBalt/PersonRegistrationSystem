using Microsoft.EntityFrameworkCore;
using PersonRegistrationSystem.DataBase.Entities;

namespace PersonRegistrationSystem.DataBase.Repositories
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        void DeleteUser(Guid id);
        User? GetUserById(Guid id);
        User? GetUserByUserName(string userName);
        List<User>? GetUsers();
        User UpdateUser(User user);
    }
    public class UserRepository: IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public Guid CreateUser(User user)
        {
            if(_context.Users.Any(u => u.UserName == user.UserName))
            {
                throw new ArgumentException("User already exists");
            }
            _context.Users.Add(user);            
            _context.SaveChanges();
            return user.Id;
        }
        public List<User>? GetUsers()
        { 
            var users = _context.Users.Include(p => p.PersonalInfo).ThenInclude(a => a.Address).ToList();
            if (users.Any() && users is not null)
            { 
                return users;
            }
            return null;
        }

        public User? GetUserById(Guid id)
        { 
            var user = _context.Users.Include(p => p.PersonalInfo).ThenInclude(a => a.Address).FirstOrDefault(x => x.Id == id);
            if (user is not null) 
            {
                return user;
            }
            return null;
        }
        public User? GetUserByUserName(string userName) 
        {
            var user = _context.Users.Include(p => p.PersonalInfo).ThenInclude(a=> a.Address).FirstOrDefault(x=> x.UserName.Contains(userName));
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        
        public void DeleteUser(Guid id)
        { 
            var user = GetUserById(id);
            if(user is not null)
            {
                var personinfo = user.PersonalInfo;
                var address = personinfo.Address;
                _context.Users.Remove(user);
                _context.PersonalInfo.Remove(personinfo);
                _context.LivingAddresses.Remove(address);
                _context.SaveChanges();
            }
            
        }


    }

   
}
