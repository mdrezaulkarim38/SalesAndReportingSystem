using Server.DTOs;
namespace Server.Services.Interfaces;
public interface ISaleService
{
    Task<string> ProcessSaleAsync(SaleDto saleDto);
}