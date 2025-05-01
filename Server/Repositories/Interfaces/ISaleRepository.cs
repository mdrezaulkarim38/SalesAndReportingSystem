using Server.Models;
namespace Server.Repositories.Interfaces;

public interface ISaleRepository
{
    Task AddSaleAsync(Sale sale);
    Task<int> CurrentSold(int id);
}