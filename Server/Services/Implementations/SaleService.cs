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
        if(product == null || product.IsDeleted)
        {
            return "Product not Found";
        }
        else if( saleDto.Quantity <= 0)
        {
            return "Quantity must be greater then zero";
        }
        else if(product.StockQty < saleDto.Quantity)
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

        product.StockQty -= saleDto.Quantity;
        product.UpdatedAt = DateTime.UtcNow;
        await _saleRepository.AddSaleAsync(sale);
        await _productRepository.UpdateAsync(product);
        
        return "Sale recorded successfully.";
    }
}