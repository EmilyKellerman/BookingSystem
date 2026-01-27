//Booking class to handle bookings
///Last updates 27/01/2026
using System;


public class Booking
{
    //auto-implemented properties
    public string RoomNumber { get; }
    public DateTime BookingDate { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public BookingStatus Status { get; }
    public string BookerName { get; }

    //List to hold booking requests - Static so all Booking instances share the same history
    private static readonly List<BookingRequest> _History = new List<BookingRequest>();

    //constructor
    public Booking ( string RoomNumber, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
    {
        this.RoomNumber = RoomNumber;
        this.BookerName = BookerName;
        this.BookingDate = BookingDate;
        this.StartTime = StartTime;
        this.EndTime = EndTime;
    }

    public Booking()
    {
        /// Default constructor   
    }
    
    //List of rooms from ConferenceRoom class - Get ALL rooms, not just available
    private List<ConferenceRoom> lstRooms = new ConferenceRoom().GetAllRooms();

    //Properties
    public IReadOnlyList<BookingRequest> History
    {
        get
        {
            return _History;
        }
    }

    public Dictionary<RoomType, List<BookingRequest>> GroupByRoomType()
        {
            var grouped = new Dictionary<RoomType, List<BookingRequest>>();

            foreach (var request in _History)
            {
                if (!grouped.ContainsKey(request.RoomType))
                {
                    grouped[request.RoomType] = new List<BookingRequest>();
                }

                grouped[request.RoomType].Add(request);
            }

            return grouped;
        }

    //Method to book a room
    public bool BookRoom(string RoomNum, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
    {
        // Find and validate the room
        ConferenceRoom targetRoom = null;
        foreach(ConferenceRoom room in lstRooms)
        {
            if(room.RoomNumber == RoomNum && room.Status == BookingStatus.Available)
            {
                targetRoom = room;
                break;
            }
        }
        
        if(targetRoom == null) return false;
        
        // Check all bookings for overlaps
        foreach(BookingRequest booking in _History)
        {
            if(booking.RoomNumber == RoomNum && 
               booking.BookingDate.Date == BookingDate.Date &&
               ((StartTime < booking.EndTime && StartTime >= booking.StartTime) ||
                (EndTime > booking.StartTime && EndTime <= booking.EndTime) ||
                (StartTime <= booking.StartTime && EndTime >= booking.EndTime)))
            {
                return false;
            }
        }
        
        // No conflicts found - create booking
        RoomType roomType = targetRoom.RoomType;
        BookingRequest newBooking = new BookingRequest(RoomNum, roomType, BookerName, BookingDate, StartTime, EndTime);
        _History.Add(newBooking);
        targetRoom.Status = BookingStatus.Booked;
        return true;
    }

/// Method to cancel a booking
public bool CancelBooking(string RoomNum, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
{
    // Find and remove the matching booking from history
    BookingRequest bookingToCancel = null;
    foreach(BookingRequest booking in _History)
    {
        if(booking.RoomNumber == RoomNum && 
           booking.BookerName == BookerName &&
           booking.BookingDate.Date == BookingDate.Date &&
           booking.StartTime == StartTime &&
           booking.EndTime == EndTime)
        {
            bookingToCancel = booking;
            break;
        }
    }
    
    if(bookingToCancel == null) return false; // Booking not found
    
    _History.Remove(bookingToCancel);
    
    // Set room back to Available if no more bookings for this room
    bool hasOtherBookings = false;
    foreach(BookingRequest booking in _History)
    {
        if(booking.RoomNumber == RoomNum)
        {
            hasOtherBookings = true;
            break;
        }
    }
    
    if(!hasOtherBookings)
    {
        foreach(ConferenceRoom room in lstRooms)
        {
            if(room.RoomNumber == RoomNum)
            {
                room.Status = BookingStatus.Available;
                break;
            }
        }
    }
    
    return true;
}
    
}