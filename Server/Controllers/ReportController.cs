using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("current-stock")]
    public async Task<IActionResult> GetCurrentStockReport()
    {
        var report = await _reportService.GetCurrentStockReportAsync();
        return Ok(report);
    }

    [HttpGet("date-wise-stock")]
    public async Task<IActionResult> GetDateWiseStockReport([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var report = await _reportService.GetDateWiseStockReportAsync(fromDate, toDate);
        return Ok(report);
    }
}
