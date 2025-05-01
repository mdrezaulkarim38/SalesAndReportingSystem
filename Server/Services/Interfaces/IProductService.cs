using System.Collections;
using Server.DTOs;
namespace Server.Services.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(ProductCreateDto product);
    Task<ProductDto> UpdateAsync(int id, ProductUpdateDto product);
    Task<ProductDto> DeleteAsync(int id);
}