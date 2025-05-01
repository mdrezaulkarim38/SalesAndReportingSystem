using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Services.Interfaces;

namespace Server.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
    {
        var product = await _productService.CreateAsync(productCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id}, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
    {
        var product = await _productService.UpdateAsync(id, productUpdateDto);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.DeleteAsync(id);
        return Ok(product);
    }
}