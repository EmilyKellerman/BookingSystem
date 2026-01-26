/// Emily Kellerman
/// Conference Room class
/// Describes what a conference room in in the logic of the business
/// Last updates 26/01/2026

public class ConferenceRoom
{
    public string RoomNum { get; private set; }
    public int Capacity { get; private set; }
    public BookingStatus Status { get; private set; }
    
    /// List of existing rooms - Private
    private List<ConferenceRoom> lstRooms = new List<ConferenceRoom>();

    public ConferenceRoom( string RoomNum, int Capacity, BookingStatus Status)
    {
        /// Setting properties
        this.Capacity = Capacity;
        this.Status = Status;
        this.RoomNum = RoomNum;

        /// If the list isn't empty then search the list for a room with the same room number
        /// If a room with the same room number exists, It will just replace that room with the new version
        if (lstRooms.Count != 0)
        {
            foreach( ConferenceRoom room in lstRooms )
            {
                if ( room.RoomNum == this.RoomNum )
                {
                    lstRooms[lstRooms.IndexOf(room)] = this;
                }
            }
            lstRooms.Add(this);
        }
        else
        {
            /// If the list is empty the room will just be added to the list
            lstRooms.Add(this);
        }
    }

    public enum BookingStatus
    {
        Available,
        Booked,
        Unavailable
    }

}