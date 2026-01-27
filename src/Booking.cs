public class Booking
{
    //auto-implemented properties
    public string RoomNumber { get; }
    public DateTime BookingDate { get; }
    public BookingStatus Status { get; }
    public string BookerName { get; }

    //constructor
    public Booking ( string RoomNumber, string BookerName, DateTime BookingDate )
    {
        this.RoomNumber = RoomNumber;
        BookRoom(RoomNumber, BookerName, BookingDate);
        this.BookerName = BookerName;
        this.BookingDate = BookingDate;

    }

    //Booking request record
    public record BookingRequest(string RoomNumber, string BookerName, DateTime BookingDate);
    //List to hold booking requests
    private List<BookingRequest> bookingRequests = new List<BookingRequest>();
    
    //List of rooms from ConferenceRoom class
    private List<ConferenceRoom> lstRooms = new ConferenceRoom().GetAvailableRooms();

    private bool BookRoom(string RoomNum, string BookerName, DateTime BookingDate)
    {
        /// Method to book a room
        foreach( ConferenceRoom room in lstRooms )
        {
            if ( room.RoomNumber == RoomNum && room.Status == BookingStatus.Available )
            {
                BookingRequest newBooking = new BookingRequest(RoomNum, "Default Booker", DateTime.Now);
                bookingRequests.Add(newBooking);
                room.Status = BookingStatus.Booked;
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }

    private bool CancelBooking(string RoomNum)
    {
        /// Method to cancel a booking
        bool CancellationSuccess = false;
        foreach( ConferenceRoom room in lstRooms )
        {
            if ( room.RoomNumber == RoomNum && room.Status == BookingStatus.Booked )
            {
                room.Status = BookingStatus.Available;
                CancellationSuccess = true;
            }
            else
            {
                CancellationSuccess = false;
            }
        }
        return CancellationSuccess;
    }

    
}