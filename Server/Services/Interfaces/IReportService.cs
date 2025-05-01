using Server.DTOs;

namespace Server.Services.Interfaces;

public interface IReportService
{
    Task<IEnumerable<CurrentStockReportDto>> GetCurrentStockReportAsync();
    Task<IEnumerable<DateWiseStockReportDto>> GetDateWiseStockReportAsync(DateTime fromDate, DateTime toDate);
}
