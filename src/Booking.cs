public class Booking
{
    //auto-implemented properties
    public string RoomNumber { get; }
    public DateTime BookingDate { get; }
    public BookingStatus Status { get; }
    public string BookerName { get; }

    //List to hold booking requests
    private readonly List<BookingRequest> _History = new List<BookingRequest>();

    //constructor
    public Booking ( string RoomNumber, string BookerName, DateTime BookingDate )
    {
        this.RoomNumber = RoomNumber;
        this.BookerName = BookerName;
        this.BookingDate = BookingDate;

    }

    public Booking()
    {
        /// Default constructor   
    }
    
    //List of rooms from ConferenceRoom class
    private List<ConferenceRoom> lstRooms = new ConferenceRoom().GetAvailableRooms();

    //Properties
    public IReadOnlyList<BookingRequest> History
    {
        get
        {
            return _History;
        }
    }

    //Method to book a room
    public bool BookRoom(string RoomNum, string BookerName, DateTime BookingDate)
    {
        bool bookSuccess = false;
        foreach( ConferenceRoom room in lstRooms )
        {
            if ( room.RoomNumber == RoomNum && room.Status == BookingStatus.Available )
            {
                BookingRequest newBooking = new BookingRequest(RoomNum, BookerName, BookingDate);
                _History.Add(newBooking);
                room.Status = BookingStatus.Booked;
                bookSuccess = true;
            }
            else
            {
                bookSuccess = false;
            }
        }
        return bookSuccess;
        
    }

    /// Method to cancel a booking
    public bool CancelBooking(string RoomNum, string BookerName, DateTime BookingDate)
    {
        /// Method to cancel a booking
        bool CancellationSuccess = false;
        foreach( ConferenceRoom room in lstRooms )
        {
            if ( room.RoomNumber == RoomNum && room.Status == BookingStatus.Booked )
            {
                BookingRequest bookingToCancel = new BookingRequest(RoomNum, BookerName, BookingDate);//I don't know if it's neccessary to create a new booking record here
                //_History.Remove(bookingToCancel);
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