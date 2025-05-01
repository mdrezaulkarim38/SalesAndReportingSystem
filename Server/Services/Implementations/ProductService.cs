using Server.DTOs;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;

namespace Server.Services.Implementations;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepo;
    public ProductService(IProductRepository productRepository)
    {
        _productRepo = productRepository;
    }

    public async Task<ProductDto> CreateAsync(ProductCreateDto productCreateDto)
    {
        var product = new Product
        {
            Name = productCreateDto.Name,
            SKU = productCreateDto.SKU,
            Price = productCreateDto.Price,
            StockQty = productCreateDto.StockQty,
            Description = productCreateDto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var createdProduct = await _productRepo.AddAsync(product);
        return MapToResponseDto(createdProduct);
    }

    public async Task<ProductDto> DeleteAsync(int id)
    {
        var product = await _productRepo.DeleteAsync(id);
        return MapToResponseDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var product = await _productRepo.GetAllAsync();
        return product.Select(p => MapToResponseDto(p));
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        return MapToResponseDto(product!);
    }

    public async Task<ProductDto> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
    {
        var product = await _productRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Product with Id {id} not found.");
        product.Name = productUpdateDto.Name;
        product.SKU = productUpdateDto.SKU;
        product.Price = productUpdateDto.Price;
        product.StockQty = productUpdateDto.StockQty;
        product.Description = productUpdateDto.Description;
        product.UpdatedAt = DateTime.UtcNow;
        var updateProduct = await _productRepo.UpdateAsync(product);
        return MapToResponseDto(updateProduct);
    }

    private static ProductDto MapToResponseDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            Price = product.Price,
            StockQty = product.StockQty,
            Description = product.Description,
            IsDeleted = product.IsDeleted,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}