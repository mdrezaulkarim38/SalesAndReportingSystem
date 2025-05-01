namespace Server.DTOs;
public class CurrentStockReportDto
{
    public string? ProductName { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int CurrentStock { get; set; }
}