public enum BookingStatus
{
    Confirmed,
    Cancelled,
    Moved               //If admin resolves a conflict

}

public enum RoomStatus          //Additional enum for the status of the rooms for bookings
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
