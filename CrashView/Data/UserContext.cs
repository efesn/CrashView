using Microsoft.EntityFrameworkCore;
using CrashView.Entities;

namespace CrashView.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(450);
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.PasswordHash).HasMaxLength(500);
            });
        }
    }
}
