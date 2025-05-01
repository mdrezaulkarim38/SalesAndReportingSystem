using System.Collections;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations;
public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted) ?? throw new KeyNotFoundException($"Product with ID {id} not Found or already deleted.");
        product.IsDeleted = true;
        product.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}