using Microsoft.EntityFrameworkCore;
using BookingSystem;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Data;
using Microsoft.VisualBasic;

public class EFBookingStore : IBookingStore
{
    private readonly AppDbContext _context;

    public EFBookingStore(AppDbContext dbContext)
    {
        _context = dbContext;
    }//ctor

    //saving booings to db
    public async Task SaveAsync(Booking booking)
    {
        _context.bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    //saving rooms to db
    public async Task SaveRoomAsync(ConferenceRoom room)
    {
        _context.conRooms.Add(room);
        await _context.SaveChangesAsync();
    }

    //load bookings from db
    public async Task<IReadOnlyList<Booking>> LoadAllAsync()
    {
        return await _context.bookings.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }

    //load rooms from db
    public async Task<IReadOnlyList<ConferenceRoom>> LoadRoomsAsync()
    {
        return await _context.conRooms.OrderByDescending(c => c.ID).ToListAsync();
    }

    public async Task CancelBookingAsync(Booking booking)
    {
        var target = _context.bookings.FirstOrDefault(b => b.Id == booking.Id
            || (b.Room != null && booking.Room != null && b.Room.RoomNumber == booking.Room.RoomNumber && b.StartTime == booking.StartTime && b.EndTime == booking.EndTime));
        if (target != null)
        {
            _context.bookings.Remove(target);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveRoomAsync(ConferenceRoom room)
    {
        var target = _context.conRooms.FirstOrDefault(r => r.RoomNumber == room.RoomNumber);
        if (target != null)
        {
            target.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }//making the room inactive rather than deleting and potentially breaking code dependent on room info

}
