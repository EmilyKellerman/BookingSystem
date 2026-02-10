using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookingSystem;
using System.Reflection.Metadata;
using System.Linq.Expressions;

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
        
        // Configure Booking entity
        modelBuilder.Entity<Booking>().HasKey(c => c.Id);
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany()
            .IsRequired(false);
        
        // Seed ConferenceRooms first
        modelBuilder.Entity<ConferenceRoom>().HasData(
            new ConferenceRoom(1, "A101", 15, RoomType.Standard)
            {
                ID = 1,
                location = "Floor 1",
                IsActive = true
            },
            new ConferenceRoom(2, "B202", 10, RoomType.Training)
            {
                ID = 2,
                location = "Floor 2",
                IsActive = true
            }
        );
        
        // Seed Bookings - EF will create the RoomID foreign key shadow property
        modelBuilder.Entity<Booking>().HasData(
            new
            {
                Id = 1,
                RoomID = 1,
                StartTime = new DateTime(2026, 2, 13, 9, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 2, 13, 10, 0, 0, DateTimeKind.Utc),
                Status = BookingStatus.Confirmed,
                CreatedAt = DateTime.UtcNow
            },
            new
            {
                Id = 2,
                RoomID = 2,
                StartTime = new DateTime(2026, 2, 14, 14, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 2, 14, 17, 0, 0, DateTimeKind.Utc),
                Status = BookingStatus.Pending,
                CreatedAt = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<ConferenceRoom>().HasKey(c => c.ID);
    }
}
