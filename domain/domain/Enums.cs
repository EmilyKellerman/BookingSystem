public enum BookingStatus
{
    Confirmed,
    Cancelled,
    Pending               //If admin resolves a conflict

}

public enum RoomType          //Additional enum for the status of the rooms for bookings
{
    Standard,
    Training,
    Boardroom
}

public enum UserRole            //Additional enum for the user role for access control to features
{
    Employee,
    Admin,
    FacilitiesManager,
    Receptionist
}
