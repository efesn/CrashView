using CrashView.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUser>(entity =>
        {
            entity.Ignore(e => e.AccessFailedCount);
            entity.Ignore(e => e.ConcurrencyStamp);
            entity.Ignore(e => e.LockoutEnabled);
            entity.Ignore(e => e.LockoutEnd);
            entity.Ignore(e => e.PhoneNumber);
            entity.Ignore(e => e.PhoneNumberConfirmed);
            entity.Ignore(e => e.SecurityStamp);
            entity.Ignore(e => e.TwoFactorEnabled);

            // Customize other properties as needed
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
        });
    }
}
