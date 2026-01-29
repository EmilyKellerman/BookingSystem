

namespace ConferenceBookingDomain{
 
 public record BookingRequest
    {
        public ConferenceRoom Room { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    

public BookingRequest(
    ConferenceRoom room,
    DateTime startTime,
    DateTime endTime)
    {
        Room = room;
        StartTime = startTime;
        EndTime = endTime;

    }

}
}