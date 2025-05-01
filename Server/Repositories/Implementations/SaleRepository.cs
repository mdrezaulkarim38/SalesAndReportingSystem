using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations;
public class SaleRepository : ISaleRepository
{
    private readonly AppDbContext _context;
    public SaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddSaleAsync(Sale sale)
    {
        _context.Add(sale);
        await _context.SaveChangesAsync();
    }
    public async Task<int> CurrentSold(int id)
    {
        return await _context.Sales
        .Where(s => s.ProductId == id)
        .SumAsync(s => s.QuantitySold);
    }
}