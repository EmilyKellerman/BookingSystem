using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ConferenceBookingDomain{
public class BookingManager     //All business rules
{
    //Properties
    private readonly List<Booking> _bookings;
    //Methods
    public IReadOnlyList<Booking> GetBookings()
    {
        return _bookings.ToList();
    }

    public Booking CreateBooking(BookingRequest request)
    {
        if(request.Room == null)
        {
            throw new ArgumentException("Room must exist");
        }
        if(request.StartTime >= request.EndTime)
            {
                throw new ArgumentException("Invalid time range");
            }
        bool overlaps = _bookings.Any(b => b.Room == request.Room && b.Status == BookingStatus.Confirmed && request.StartTime < b.EndTime && request.EndTime > b.StartTime);

            if (overlaps)
            {
                throw new BookingConflictException();
            }

            Booking booking = new Booking(request.Room, request.StartTime, request.EndTime);

            booking.Confirm();
            _bookings.Add(booking);

            return booking;

    }

}
}





    





