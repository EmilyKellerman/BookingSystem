using System.ComponentModel.DataAnnotations;

public class authorizeLoginDto
{
    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }
}
