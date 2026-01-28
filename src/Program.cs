/// Last Updated 27/01/2026
/// Client of Booking System

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        #region welcoming and menu
        ///introduction message and menu selection
        Console.WriteLine("===================================");
        Console.WriteLine("Welcome to the Booking System");
        Console.WriteLine("Please select an option from the menu below:");

        /// Menu options
        Console.WriteLine("1: Book a Conference Room");
        Console.WriteLine("2: Cancel a Booking");
        Console.WriteLine("3: Export Booking history as json file");
        Console.WriteLine("4: Load history from file");
        Console.WriteLine("===================================");
        Console.WriteLine("Please enter the number of your selection:");
        #endregion


        /// Get user input
        int input = int.Parse(Console.ReadLine());
        ConferenceRoom conferenceRoom = new ConferenceRoom();
        switch (input)
        {
            case 1:
            #region case 1: Book a room

                Console.WriteLine("You have selected to book a conference room.");
                Console.WriteLine("List of available rooms:");
                
                // Display available rooms
                List<ConferenceRoom> rooms = new ConferenceRoom().GetAllRooms();
                foreach( ConferenceRoom room in rooms )
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}, Room Type: {room.RoomType} Room Name: {room.RoomName}, Capacity: {room.Capacity}, Status: {room.Status}");
                }

                Console.WriteLine("Please enter the room number you wish to book:");
                string? roomNum = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(roomNum))
                {
                    throw new InvalidRoomNumberException();
                }

                Console.WriteLine("Please enter your name:");
                string? bookerName = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(bookerName))
                {
                    bookerName = "Annonymous";
                }

                /// Validation that all the dates and times given are valid formats
                Console.WriteLine("Please enter the date you wish to book the room for (yyyy-MM-dd):");
                DateTime BookingDate;
                try
                {
                    /// If the input fails to parse into a DateTime variable exception is thrown
                    DateTime.TryParse(Console.ReadLine(), out BookingDate);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid Date. Please check the format and try again");
                }

                Console.WriteLine("Please enter the start time (HH:mm):");
                DateTime startTime;
                try
                {
                    DateTime.TryParse(Console.ReadLine(), out startTime);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid Time. Please check the format and try again");
                }

                Console.WriteLine("Please enter the end time (HH:mm):");
                DateTime endTime;
                try
                {
                    DateTime.TryParse(Console.ReadLine(), out endTime);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid Time. Please check the format and try again");
                }

                //once all data that has been input is correct, create a placeholder booking
                Booking Booking = new Booking();

                ///Booking room
                if (Booking.BookRoom(roomNum, bookerName, BookingDate, startTime, endTime))
                {//if successful booking
                    Console.WriteLine("Information processed successfully.");
                    Console.WriteLine("Booking pending");

                    //confirm booking completion
                    Console.WriteLine($"Are you sure you want to book {roomNum}, on {BookingDate}, at {startTime} until {endTime}?");
                    Console.Write("Y/N"); 
                    
                    //validate user input
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y"://Confirm booking creation
                            Console.WriteLine("Room successfully booked.");
                            break;

                        case "N"://Cancel booking, delete it from history
                            Booking.CancelBooking(roomNum, bookerName, BookingDate, startTime, endTime);
                            break;

                        default://Invalid input was given
                            throw new Exception ("Invalid selection. Check the options and try again.");
                    }
                }
                else
                {
                    throw new Exception ("Booking failed. Please check the room number and try again.");
                }
                
                break;//Case 1
                #endregion

            case 2:
            #region Case 2: Cancel Booking
                Console.WriteLine("You have selected to cancel a booking.");
                // Call cancellation method here
                Console.WriteLine("Please enter the room number of the booking you wish to cancel:");
                roomNum = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(roomNum))
                {
                    throw new InvalidRoomNumberException();
                }

                Console.WriteLine("Please enter your name:");
                bookerName = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(bookerName))
                {
                    bookerName = "Annonymous";
                }

                Console.WriteLine("Please enter the date of the booking you wish to cancel (yyyy-MM-dd):");
                DateTime CancelDate;
                try
                {
                    /// If the input fails to parse into a DateTime variable exception is thrown
                    DateTime.TryParse(Console.ReadLine(), out CancelDate);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid Date. Please check the format and try again");
                }

                Console.WriteLine("Please enter the start time of the booking you wish to cancel (HH:mm):");
                DateTime CancelStartTime;
                try
                {
                    /// If the input fails to parse into a DateTime variable exception is thrown
                    DateTime.TryParse(Console.ReadLine(), out CancelStartTime);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid time. Please check the format and try again");
                }

                Console.WriteLine("Please enter the end time of the booking you wish to cancel (HH:mm):");
                DateTime CancelEndTime;
                try
                {
                    /// If the input fails to parse into a DateTime variable exception is thrown
                    DateTime.TryParse(Console.ReadLine(), out CancelEndTime);
                }
                catch(Exception ex)
                {
                    throw new InvalidDataException (ex + ": Invalid Date. Please check the format and try again");
                }


                Booking booking = new Booking();

                if (booking.CancelBooking(roomNum, bookerName, CancelDate, CancelStartTime, CancelEndTime))
                {
                    Console.WriteLine("Booking successfully cancelled.");
                }
                else
                {
                    Console.WriteLine("Cancellation failed. Please check the room number and try again.");
                }
                break;//case 2
                #endregion

            case 3:
            #region Exporting to file
                ////Export BookingRequest list as json
                Booking bking = new Booking();
                await bking.SaveHistoryAsync();
                break;//Case 3
            #endregion

            case 4:
            #region Load from file
                ///Reading history from file
                Booking bkingRead = new Booking();
                await bkingRead.LoadHistoryAsync();
                break;//Case 4
            #endregion

            default:
                Console.WriteLine("Invalid selection. Please try again.");
                break;
        }//Switch      
    }
}