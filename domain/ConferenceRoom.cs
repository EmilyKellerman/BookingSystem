namespace ConferenceBookingDomain
{
    public class ConferenceRoom
    {
        //Roomtype

        public int ID { get; }

        public string RoomNumber { get; }

        public int Capacity { get; }

        public RoomStatus Status { get; set; }

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
