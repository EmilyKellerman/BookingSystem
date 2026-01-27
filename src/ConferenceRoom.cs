/// Conference Room class
/// Describes what a conference room is in the logic of the business
/// Last updates 27/01/2026

public class ConferenceRoom
{
    /// Properties -> All of them are readonly outside of the class
    /// A separate class can be made available to manage room creation and updates by the admin staff type in the future
    public string RoomNumber { get; }
    public string RoomName { get; }
    public int Capacity { get; }
    public RoomType RoomType { get;}

    //Must be able to change the status when its booked, available or under maintenance, therefore not readonly
    public BookingStatus Status { get; set; }

    public ConferenceRoom( string RoomNumber, string RoomName, int Capacity, RoomType RoomType = RoomType.Medium )
    {
        /// Setting field values
        this.RoomNumber = RoomNumber;
        this.RoomName = RoomName;
        this.Capacity = Capacity;
        this.Status = BookingStatus.Available;
        this.RoomType = RoomType;

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

    /// List of existing rooms - Private and Static so all instances share the same list
    private static List<ConferenceRoom> lstRooms = new List<ConferenceRoom>();
    

    public ConferenceRoom()
    {
        // default constructor
    }

    public List<ConferenceRoom> GetAvailableRooms()
    {
        /// Method to get a list of available rooms using LINQ
        List<ConferenceRoom> availableRooms = lstRooms.Where(room => room.Status == BookingStatus.Available).ToList();
        return availableRooms;
    }

    public List<ConferenceRoom> GetAllRooms()
    {
        /// Method to get all rooms regardless of status
        return new List<ConferenceRoom>(lstRooms);
    }
}