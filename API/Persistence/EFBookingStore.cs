using Microsoft.EntityFrameworkCore;
using domain.Domain;
using domain.Persistence;

public class EFBookingStore : IBookingStore
{
    private readonly AppDbContext _context;

    public EFBookingStore(AppDbContext dbContext)
    {
        _context = dbContext;
    }//ctor

    public async Task SaveAsync(Booking booking)
    {
        _context.bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Booking>> LoadAllAsync()
    {
        return await _context.bookings.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }

}