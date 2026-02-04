

namespace BookingSystem
{
 
 public record RoomRequest
{
    public ConferenceRoom Room { get; }
    

    public RoomRequest(ConferenceRoom room)
    {
        Room = room;
    }

}
}