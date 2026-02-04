using BookingSystem;

public interface IBookingStore
{
    Task SaveAsync(IEnumerable<Booking> bookings);
    Task<List<Booking>> LoadAsync();
}