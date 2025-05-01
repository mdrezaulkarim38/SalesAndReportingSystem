using System.ComponentModel.DataAnnotations;

namespace Server.DTOs;

public class RegisterDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}