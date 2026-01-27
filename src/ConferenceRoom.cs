/// Emily Kellerman
/// Conference Room class
/// Describes what a conference room in in the logic of the business
/// Last updates 26/01/2026

/// Conference Room class
/// Defines properties and methods related to conference rooms

public class ConferenceRoom
{
    /// Properties -> All of them are readonly outside of the class
    /// A separate class can be made available to manage room creation and updates by the admin staff type in the future
    public string RoomNumber { get; }
    public string RoomName { get; }
    public int Capacity { get; }

    //Must be able to change the status when its booked, available or under maintenance, therefore not readonly
    public BookingStatus Status { get; set; }

    public ConferenceRoom( string RoomNumber, string RoomName, int Capacity)
    {
        /// Setting properties
        this.RoomNumber = RoomNumber;
        this.RoomName = RoomName;
        this.Capacity = Capacity;
        this.Status = BookingStatus.Available;

        /// If the list isn't empty then search the list for a room with the same room number
        /// If a room with the same room number exists, It will just replace that room with the new version
        if (lstRooms.Count != 0)
        {
            foreach( ConferenceRoom room in lstRooms )
            {
                if ( room.RoomNumber == this.RoomNumber )
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

    /// List of existing rooms - Private
    private List<ConferenceRoom> lstRooms = new List<ConferenceRoom>();
    

    public ConferenceRoom()
    {
        if ( string.IsNullOrWhiteSpace(RoomNumber) )
        {
            throw new ArgumentException("Room must have a number");
        }   
        else if ( string.IsNullOrWhiteSpace(RoomName) )
        {
            throw new ArgumentException("Room must have a name");
        }
        else if ( Capacity <= 0 )
        {
            Capacity = 1;
        }
            
    }

    public List<ConferenceRoom> GetAvailableRooms()
    {
        /// Method to get a list of available rooms
        List<ConferenceRoom> availableRooms = new List<ConferenceRoom>();
        foreach( ConferenceRoom room in lstRooms )
        {
            if ( room.Status == BookingStatus.Available )
            {
                availableRooms.Add(room);
            }
        }
        return availableRooms;
    }
}