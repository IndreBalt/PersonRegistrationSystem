using Microsoft.EntityFrameworkCore;
using PersonRegistrationSystem.DataBase.Entities;

namespace PersonRegistrationSystem.DataBase
{
    public class UserDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LivingAddress> LivingAddresses { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
