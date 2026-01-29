namespace ConferenceBookingDomain
{
    public class SeedData()
    {
        public List<ConferenceRoom> SeedRooms()
        {
            List<ConferenceRoom> ConferenceRoom = new List<ConferenceRoom>()
        {
        new ConferenceRoom (1, "Room A", 10, RoomStatus.Standard),
new ConferenceRoom (2, "Room B", 20, RoomStatus.Boardroom),
new ConferenceRoom (3, "Room C", 15,  RoomStatus.Training),
new ConferenceRoom (4, "Room D", 25,  RoomStatus.Standard),
new ConferenceRoom (5, "Room E", 30, RoomStatus.Boardroom),
new ConferenceRoom (6, "Room F", 10,  RoomStatus.Training),
new ConferenceRoom (7, "Room G", 20,  RoomStatus.Standard),
new ConferenceRoom (8, "Room H", 15,  RoomStatus.Boardroom),
new ConferenceRoom (9, "Room I", 13,  RoomStatus.Training),
new ConferenceRoom (10, "Room J", 20,  RoomStatus.Standard),
new ConferenceRoom (11, "Room K", 10,  RoomStatus.Boardroom),
new ConferenceRoom (12, "Room L", 5,  RoomStatus.Training),
new ConferenceRoom (13, "Room M", 12,  RoomStatus.Standard),
new ConferenceRoom (14, "Room N", 15,  RoomStatus.Boardroom),
new ConferenceRoom (15, "Room O", 12,  RoomStatus.Training),
new ConferenceRoom (16, "Room P", 30,  RoomStatus.Standard),
    };
            return ConferenceRoom;
        }
    }
}