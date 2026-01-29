using ConferenceBookingDomain;

namespace ConferenceBookingDomain{
public class Booking
{
    public ConferenceRoom Room { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public BookingStatus Status { get; set; }



    public Booking (ConferenceRoom room, DateTime start, DateTime end){
        Room = room;    //Validation in conference room
        StartTime = start;
        EndTime = end;
    }
    
    


    public void Confirm()
        {
            Status = BookingStatus.Confirmed;
        }



    public Booking Cancel()
    {
        

        Status = BookingStatus.Cancelled;
        return this;
    }



}
}