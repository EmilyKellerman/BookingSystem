using BookingSystem;

namespace BookingSystem
{
public class Booking
{
    public int Id { get; set; }
    public ConferenceRoom Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Parameterless constructor for EF Core
    public Booking() { }

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
