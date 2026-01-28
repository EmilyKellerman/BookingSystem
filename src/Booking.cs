//Booking class to handle bookings
///Last updates 27/01/2026
using System;


public class Booking
{
    //auto-implemented properties
    private ConferenceRoom conferenceRoom { get; set; }
    public DateTime BookingDate { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public BookingStatus Status { get; }
    public string BookerName { get; }

    //List to hold booking requests - Static so all Booking instances share the same history
    private static readonly List<BookingRequest> _History = new List<BookingRequest>();

    //constructor
    public Booking ( ConferenceRoom conferenceRoom, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
    {
        this.conferenceRoom = conferenceRoom;
        this.BookerName = BookerName;
        this.BookingDate = BookingDate;
        this.StartTime = StartTime;
        this.EndTime = EndTime;

        //create a record of the booking and add it to the history
        BookingRequest bookingRequest = new BookingRequest(this);
        _History.Add(bookingRequest);
    }

    public Booking()
    {
        ///
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

    //using dictionary to group the booking requests by room type
    public Dictionary<RoomType, List<BookingRequest>> GroupByRoomType()
        {
            Dictionary<RoomType, List<BookingRequest>> grouped = new Dictionary<RoomType, List<BookingRequest>>();

            foreach (BookingRequest request in _History)
            {
                if (!grouped.ContainsKey(request.Booking.conferenceRoom.RoomType))
                {
                    grouped[request.Booking.conferenceRoom.RoomType] = new List<BookingRequest>();
                }

                grouped[request.Booking.conferenceRoom.RoomType].Add(request);
            }

            return grouped;
        }

    //Method to book a room
    public bool BookRoom(string RoomNum, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
    {
        //The dates will have been validated in the client before being passed into this method
        try
        {
            //checking to see if the conference room exists
            ConferenceRoom conferenceRoom = lstRooms.First(s => s.RoomNumber == RoomNum);

            if ( _History.Count() == 0 )
            {
                Booking booking = new Booking(conferenceRoom, BookerName, BookingDate, StartTime, EndTime);
                return true;
            }
            else
            {
                //looking for a booking in the history that matches the one trying to be made
                BookingRequest bookingRequest = _History.First(s => s.Booking.conferenceRoom == conferenceRoom
                                                && s.Booking.BookerName == BookerName && s.Booking.BookingDate == BookingDate
                                                && s.Booking.StartTime == StartTime && s.Booking.EndTime == EndTime );
                if( bookingRequest == null )
                {//if no request in the history matches, then booking is available and can be made without duplication
                    Booking booking = new Booking(conferenceRoom, BookerName, BookingDate, StartTime, EndTime);
                    return true;
                }
                else
                {//duplicate was found and booking cannot be made
                    throw new Exception ("Booking already exists.");
                }
            }//if/else end
            
        }//try
        catch (Exception ex)
        {
             //if none of the rooms have the same number then no room was found so throw exception
             throw new InvalidDataException ( ex + ": Invalid room number given. Please check it and try again." );
             //return false;
        }//catch
        
    }//BookRoom

/// Method to cancel a booking
public bool CancelBooking(string RoomNum, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime)
{
    //The dates will have been validated in the client before being passed into this method
        try
        {
            //checking to see if the conference room exists
            ConferenceRoom conferenceRoom = lstRooms.First(s => s.RoomNumber == RoomNum);

            if ( _History.Count() == 0 )
            {
                throw new Exception ("There are no bookings to cancel.");
            }
            else
            {
                //looking for a booking in the history that matches the one trying to be made
                BookingRequest bookingRequest = _History.First(s => s.Booking.conferenceRoom == conferenceRoom
                                                && s.Booking.BookerName == BookerName && s.Booking.BookingDate == BookingDate
                                                && s.Booking.StartTime == StartTime && s.Booking.EndTime == EndTime );
                if( bookingRequest == null )
                {//if no request in the history matches, then the booking the user wants to cancel doesn't exist and cancellation fails
                    throw new Exception ( "No booking matching the given data was found, please check the information and try again.");
                }
                else
                {//The booking was found in the history and will be removed from the history
                    
                    _History.Remove(bookingRequest);
                    return true;
                }
            }//if else
            
        }//try
        catch (Exception ex)
        {
             //if none of the rooms have the same number then no room was found so throw exception
             throw new InvalidDataException ( ex + ": Invalid room number given. Please check it and try again." );
             //return false;
        }//catch
}
    
}