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

public class EFBookingStore : IBookingStore
{
    private readonly AppDbContext _context;

    public EFBookingStore(AppDbContext dbContext)
    {
        _context = dbContext;
    }//ctor

    //saving booings to db
    public async Task SaveBookingAsync(Booking booking)
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
    public async Task<IReadOnlyList<Booking>> LoadBookingsAsync()
    {
        return await _context.bookings.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }

    //load rooms from db
    public async Task<IReadOnlyList<Booking>> LoadRoomsAsync()
    {
        return await _context.conRooms.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }

    public async Task RemoveRoomAsync(ConferenceRoom room)
    {
        var target = _context.conRooms.First(r => r.RoomNumber == room.roomNumber);
        target.IsActive = false;
        return await _context.conRooms.SaveChangesAsync();
    }//making the room inactive rather than deleting and potentially breaking code dependent on room info

}
