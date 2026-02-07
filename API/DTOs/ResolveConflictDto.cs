using System.ComponentModel.DataAnnotations;

public class ResolveConflictDto
{
    [Required]
    public string bookingId { get; set; }

    [Required]
    public string resolution { get; set; } // "approve" or "reject"

    public string notes { get; set; }
}
