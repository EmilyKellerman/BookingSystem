using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using BookingSystem;

public class CancelBookingDto
{
    [Required]
    public ConferenceRoom room { get; set; }
    [Required]
    public DateTime startTime { get; set; }
    [Required]
    public DateTime endTime { get; set; }
}