using System.ComponentModel.DataAnnotations;

namespace Server.DTOs;

public class LoginDto
{
    [Required]
    [MaxLength(50)]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}