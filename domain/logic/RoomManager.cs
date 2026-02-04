using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem
{
public class RoomManager     //All business rules
{
    //Properties
    private readonly List<ConferenceRoom> _rooms;

    public RoomManager()
    {
        _rooms = new List<ConferenceRoom>();
    }
    
    //Methods
    public IReadOnlyList<ConferenceRoom> GetRooms()
    {
        return _rooms.ToList();
    }

    public ConferenceRoom CreateRoom(RoomRequest request)
    {
        if(request.Room == null)
        {
            throw new ArgumentException("Room must exist");
        }
        bool overlaps = _rooms.Any(b => b.RoomNumber == request.Room.RoomNumber);

            if (overlaps)
            {
                throw new ArgumentException("Room Number already used");
            }

            ConferenceRoom room = new ConferenceRoom(request.Room.ID, request.Room.RoomNumber, request.Room.Capacity, request.Room.Status);

            _rooms.Add(room);

            return room;

    }

    //DeleteRoom
    public bool DeleteRoom(RoomRequest request)
    {
        if(request.Room == null)
        {
            throw new ArgumentException("Room must exist");
        }

        bool overlaps = _rooms.Any(b => b.RoomNumber == request.Room.RoomNumber);
        //if there are any overlaps, thats the booking we want to cancel, so we cancel it by removing it from _bookings
        if (overlaps)
        {
            _rooms.Remove(_rooms.First(b => b.RoomNumber == request.Room.RoomNumber));
            return true;
        }
            else
            {
                return false;
            }

    }

}
}





    





