using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using BookingSystem;

public class CreateRoomDto
{
    [Required]
    public ConferenceRoom room { get; set; }
}