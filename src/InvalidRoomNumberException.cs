public class InvalidRoomNumberException : Exception
{
    public InvalidRoomNumberException() :base("Room number cannot be null or blank space.")
    {
        
    }
}