///Emily Kellerman
/// Last Updated 26/01/2026
/// Client of Booking System

using System;

class Program
{
    static void Main(string[] args)
    {
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
        switch (input)
        {
            case "1":
                Console.WriteLine("You have selected to book a conference room.");
                Console.WriteLine("List of available rooms:");
                // Call booking method here
                break;

            case "2":
                Console.WriteLine("You have selected to cancel a booking.");
                // Call cancellation method here
                break;

            case "3":
                Console.WriteLine("You have selected to log in as admin.");
                Console.WriteLine("Please enter your Employee number:");
                string empNumber = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                // Call admin login method here
                break;

            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }        
    }
}