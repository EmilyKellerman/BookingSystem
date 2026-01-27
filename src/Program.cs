///Emily Kellerman
/// Last Updated 26/01/2026
/// Client of Booking System

using System;

/// The booking logic
class Program
{
    static void Main(string[] args)
    {
        //Hardcoded rooms for testing purposes
        ConferenceRoom room1 = new ConferenceRoom("101", "Alpha", 10);
        ConferenceRoom room2 = new ConferenceRoom("102", "Beta", 20);
        ConferenceRoom room3 = new ConferenceRoom("201", "Gamma", 15);
        ConferenceRoom room4 = new ConferenceRoom("202", "Delta", 25);
        ConferenceRoom room5 = new ConferenceRoom("301", "Epsilon", 50);

        ///introduction message and menu selection
        Console.WriteLine("Welcome to the Booking System");
        Console.WriteLine("Please select an option from the menu below:");

        /// Menu options
        Console.WriteLine("1: Book a Conference Room");
        Console.WriteLine("2: Cancel a Booking");
        Console.WriteLine("3: Log in as Admin");
        Console.WriteLine("Please enter the number of your selection:");

        /// Get user input
        string input = Console.ReadLine();
        ConferenceRoom conferenceRoom = new ConferenceRoom();
        switch (input)
        {
            case "1":
                Console.WriteLine("You have selected to book a conference room.");
                Console.WriteLine("List of available rooms:");
                // Call booking method here
                Console.WriteLine(new ConferenceRoom().GetAvailableRooms().ToString());

                Console.WriteLine("Please enter the room number you wish to book:");
                string roomToBook = Console.ReadLine();

                Console.WriteLine("Please enter your name:");
                string bookerName = Console.ReadLine();

                Console.WriteLine("Please enter the date you wish to book the room for (YYYY-MM-DD):");
                string dateInput = Console.ReadLine();

                Booking



                if (bookSuccess)
                {
                    Console.WriteLine("Room successfully booked.");
                }
                else
                {
                    Console.WriteLine("Booking failed. Please check the room number and try again.");
                }
                
                break;

            case "2":
                Console.WriteLine("You have selected to cancel a booking.");
                // Call cancellation method here
                Console.WriteLine("Please enter the room number of the booking you wish to cancel:");
                string roomNum = Console.ReadLine();
                bool cancelSuccess = conferenceRoom.CancelBooking(roomNum);
                if (cancelSuccess)
                {
                    Console.WriteLine("Booking successfully cancelled.");
                }
                else
                {
                    Console.WriteLine("Cancellation failed. Please check the room number and try again.");
                }
                break;

            case "3":
                Console.WriteLine("You have selected to log in as admin.");
                Console.WriteLine("Please enter your Employee number:");
                string empNumber = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                // Call admin login method here - will be added in the future
                break;

            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }        
    }
}