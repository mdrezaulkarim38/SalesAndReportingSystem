using Server.DTOs;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
namespace Server.Services.Implementations;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }
    public async Task<string> ProcessSaleAsync(SaleDto saleDto)
    {
        var product = await _productRepository.GetByIdAsync(saleDto.ProductId);
        if (product == null || product.IsDeleted)
        {
            return "Product not found.";
        }
        else if (saleDto.Quantity <= 0)
        {
            return "Quantity must be greater than zero.";
        }
        int totalSold = await _saleRepository.CurrentSold(product.Id);
        int currentStock = product.StockQty - totalSold;
        if (currentStock < saleDto.Quantity)
        {
            return "Insufficient stock.";
        }

        decimal totalPrice = product.Price * saleDto.Quantity;
        var sale = new Sale
        {
            ProductId = product.Id,
            QuantitySold = saleDto.Quantity,
            TotalPrice = totalPrice,
            SaleDate = DateTime.Now
        };

        await _saleRepository.AddSaleAsync(sale);

        return "Sale recorded successfully.";
    }

}