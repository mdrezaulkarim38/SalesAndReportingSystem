using System.ComponentModel.DataAnnotations;
namespace Server.DTOs;
public class ProductDto
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [StringLength(50)]
    public string? SKU { get; set; }
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int StockQty { get; set; }
    [StringLength(500)]
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}