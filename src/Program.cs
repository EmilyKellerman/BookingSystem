/// Last Updated 27/01/2026
/// Client of Booking System

using System;

class Program
{
    static void Main(string[] args)
    {
        //Hardcoded rooms for testing purposes
        ConferenceRoom room1 = new ConferenceRoom("101", "Alpha", 10, RoomType.Small);
        room1.Status = BookingStatus.Available;

        ConferenceRoom room2 = new ConferenceRoom("102", "Beta", 20, RoomType.Medium);
        room2.Status = BookingStatus.Available;

        ConferenceRoom room3 = new ConferenceRoom("201", "Gamma", 15, RoomType.Small);
        room3.Status = BookingStatus.Available;

        ConferenceRoom room4 = new ConferenceRoom("202", "Delta", 25, RoomType.Large);
        room4.Status = BookingStatus.Available;

        ConferenceRoom room5 = new ConferenceRoom("301", "Epsilon", 50, RoomType.Auditorium);
        room5.Status = BookingStatus.UnderMaintenance;

        ///introduction message and menu selection
        Console.WriteLine("===================================");
        Console.WriteLine("Welcome to the Booking System");
        Console.WriteLine("Please select an option from the menu below:");

        /// Menu options
        Console.WriteLine("1: Book a Conference Room");
        Console.WriteLine("2: Cancel a Booking");
        Console.WriteLine("3: View list of Rooms grouped by Room Type");
        Console.WriteLine("===================================");
        Console.WriteLine("Please enter the number of your selection:");

        /// Get user input
        int input = int.Parse(Console.ReadLine());
        ConferenceRoom conferenceRoom = new ConferenceRoom();
        switch (input)
        {
            case 1:
                Console.WriteLine("You have selected to book a conference room.");
                Console.WriteLine("List of available rooms:");
                
                // Display available rooms
                List<ConferenceRoom> rooms = new ConferenceRoom().GetAvailableRooms();
                foreach( ConferenceRoom room in rooms )
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}, Room Type: {room.RoomType} Room Name: {room.RoomName}, Capacity: {room.Capacity}, Status: {room.Status}");
                }

                Console.WriteLine("Please enter the room number you wish to book:");
                string roomNum = Console.ReadLine();

                Console.WriteLine("Please enter your name:");
                string bookerName = Console.ReadLine();

                Console.WriteLine("Please enter the date you wish to book the room for (yyyy-MM-dd):");
                string dateInput = Console.ReadLine();

                Console.WriteLine("Please enter the start time (HH:mm):");
                string startTimeInput = Console.ReadLine();

                Console.WriteLine("Please enter the end time (HH:mm):");
                string endTimeInput = Console.ReadLine();

                
                Booking Booking = new Booking();


                if (Booking.BookRoom(roomNum, bookerName, DateTime.Parse(dateInput), DateTime.Parse(startTimeInput), DateTime.Parse(endTimeInput)))
                {
                    
                    Console.WriteLine("Room successfully booked.");
                }
                else
                {
                    Console.WriteLine("Booking failed. Please check the room number and try again.");
                }
                
                break;

            case 2:
                Console.WriteLine("You have selected to cancel a booking.");
                // Call cancellation method here
                Console.WriteLine("Please enter the room number of the booking you wish to cancel:");
                roomNum = Console.ReadLine();

                Console.WriteLine("Please enter your name:");
                bookerName = Console.ReadLine();

                Console.WriteLine("Please enter the date of the booking you wish to cancel (yyyy-MM-dd):");
                dateInput = Console.ReadLine();

                Console.WriteLine("Please enter the start time of the booking you wish to cancel (HH:mm):");
                startTimeInput = Console.ReadLine();

                Console.WriteLine("Please enter the end time of the booking you wish to cancel (HH:mm):");
                endTimeInput = Console.ReadLine();


                Booking booking = new Booking();

                if (booking.CancelBooking(roomNum, bookerName, DateTime.Parse(dateInput), DateTime.Parse(startTimeInput), DateTime.Parse(endTimeInput)))
                {
                    Console.WriteLine("Booking successfully cancelled.");
                }
                else
                {
                    Console.WriteLine("Cancellation failed. Please check the room number and try again.");
                }
                break;

            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }        
    }
}