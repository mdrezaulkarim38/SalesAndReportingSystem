using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Services.Interfaces;

namespace Server.Services.Implementations;

public class ReportService : IReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CurrentStockReportDto>> GetCurrentStockReportAsync()
    {
        var products = await _context.Products.ToListAsync();
        var sales = await _context.Sales.ToListAsync();

        var report = products.Select(product =>
        {
            var sold = sales
                .Where(s => s.ProductId == product.Id)
                .Sum(s => s.QuantitySold);

            return new CurrentStockReportDto
            {
                ProductName = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                CurrentStock = product.StockQty - sold
            };
        });

        return report;
    }

    public async Task<IEnumerable<DateWiseStockReportDto>> GetDateWiseStockReportAsync(DateTime fromDate, DateTime toDate)
    {
        var products = await _context.Products.ToListAsync();
        var sales = await _context.Sales.ToListAsync();

        var report = products.Select(product =>
        {
            var soldBefore = sales
                .Where(s => s.ProductId == product.Id && s.SaleDate < fromDate)
                .Sum(s => s.QuantitySold);

            var soldInRange = sales
                .Where(s => s.ProductId == product.Id && s.SaleDate >= fromDate && s.SaleDate <= toDate)
                .Sum(s => s.QuantitySold);

            var openingStock = product.StockQty - soldBefore;
            var closingStock = openingStock - soldInRange;

            return new DateWiseStockReportDto
            {
                ProductName = product.Name,
                OpeningStock = openingStock,
                SoldQuantity = soldInRange,
                ClosingStock = closingStock
            };
        });

        return report;
    }
}
