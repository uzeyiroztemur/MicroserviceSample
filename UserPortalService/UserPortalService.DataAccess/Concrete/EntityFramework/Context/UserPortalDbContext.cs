using Microsoft.EntityFrameworkCore;
using System.Configuration;
using UserPortalService.Entities.Models;

namespace UserPortalService.DataAccess.Concrete.EntityFramework.Context
{
    public class UserPortalDbContext : DbContext
    {
        public UserPortalDbContext()
        {

        }

        public UserPortalDbContext(DbContextOptions<UserPortalDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("User ID=postgres;Password=123456;Server=127.0.0.1;Port=5432;Database=UserPortalDb;Integrated Security=true;");

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

    }
}