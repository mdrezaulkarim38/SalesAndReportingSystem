using System.ComponentModel.DataAnnotations;

namespace Server.DTOs;
public class SaleDto
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
}