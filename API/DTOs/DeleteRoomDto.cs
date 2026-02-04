using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using BookingSystem;

public class DeleteRoomDto
{
    [Required]
    public ConferenceRoom room { get; set; }
}