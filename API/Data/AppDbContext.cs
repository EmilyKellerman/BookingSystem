using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Persistence;
public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public DbSet<Booking> bookings { get; set; }
    public DbSet<ConferenceRoom> conRooms { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<bookings>().HasKey(c => c.Id);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<conRooms>().HasKey(c => c.Id);
    }
}
