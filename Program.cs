using ConferenceBookingDomain;
using System;



static async Task Main()
{
    SeedData data = new SeedData();
    List<ConferenceRoom> rooms = data.SeedRooms();
    BookingManager manager = new BookingManager();
    BookingFileStore store = new BookingFileStore("history.json");




    try
    {
        manager.CreateBooking(new BookingRequest(rooms[0], DateTime.Now, DateTime.Now.AddHours(1)));

        await store.SaveAsync(manager.GetBookings());

    }
    catch (BookingConflictException ex)
    {
        System.Console.WriteLine(ex.Message);
    }
}


