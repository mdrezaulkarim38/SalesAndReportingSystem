namespace Server.Models;

public class Sale
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int QuantitySold { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.Now;
    public Product? Product { get; set; }
}