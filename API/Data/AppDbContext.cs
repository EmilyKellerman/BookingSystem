using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookingSystem;

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
        modelBuilder.Entity<Booking>().HasKey(c => c.Id);
        modelBuilder.Entity<ConferenceRoom>().HasKey(c => c.ID);
    }
}
