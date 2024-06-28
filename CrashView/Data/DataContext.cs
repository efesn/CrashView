using CrashView.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Role)
            .WithMany(r => r.Persons)
            .HasForeignKey(p => p.Role_ID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Persons)
            .HasForeignKey(p => p.Team_ID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
