// Booking request record
/// Last updated 27/01/2026
    public record BookingRequest(string RoomNumber, RoomType RoomType, string BookerName, DateTime BookingDate, DateTime StartTime, DateTime EndTime);