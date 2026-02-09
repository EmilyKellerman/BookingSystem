using BookingSystem;

public interface IBookingStore
{
    Task SaveAsync(Booking booking);
    Task<IReadOnlyList<Booking>> LoadAllAsync();
}