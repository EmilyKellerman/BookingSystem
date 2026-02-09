namespace BookingSystem
{
    public class ConferenceRoom
    {
        //Roomtype

        public int ID { get; set; }

        public string RoomNumber { get; set; }

        public int Capacity { get; set; }

        public RoomStatus Status { get; set; }

        // Parameterless constructor for EF Core
        public ConferenceRoom() { }

        public ConferenceRoom(int id, string roomNumber, int capacity, RoomStatus status)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                throw new Exception("A room number must be entered");
            }
            if (capacity < 10 || capacity > 20)
            {
                throw new Exception("Capacity must be between 10 and 20");
                //Assuming there are rooms with a min of 10 and the max of 20
            }

            ID = id;
            RoomNumber = roomNumber;
            Capacity = capacity;
            Status = status;
        }

        

        





    }
}
