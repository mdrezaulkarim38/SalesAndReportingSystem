using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Services.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaleDto saleDto)
    {
        var result = await _saleService.ProcessSaleAsync(saleDto);
        if(result == "Sale recorded successfully.")
        {
            return Ok(new { message  = result});
        }
        return BadRequest(new { error = result });
    }
}