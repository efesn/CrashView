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
    public DbSet<PersonTeamHistory> PersonTeams { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Season> Season { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceResult> RaceResults { get; set; }
    public DbSet<Crash> Crashes { get; set; }
    public DbSet<User> Users { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Role)
            .WithMany() 
            .HasForeignKey(p => p.Role_ID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Team)
            .WithMany() 
            .HasForeignKey(p => p.Team_ID)
            .OnDelete(DeleteBehavior.Restrict);
    }

public DbSet<CrashView.Entities.PersonTeamHistory> PersonTeamHistory { get; set; } = default!;

public DbSet<CrashView.Entities.Track> Track { get; set; } = default!;
}
