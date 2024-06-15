using Microsoft.AspNetCore.Mvc;
using Scraping.Application.DTOs;
using Scraping.Application.Interfaces;
using Scraping.Domain.Entities;
using Scraping.Domain.Interfaces;

namespace Scraping.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpPost("scrape")]
    public async Task<ActionResult<List<FoodItem>>> Scrape()
    {
        var scrapedFoodItems = await _foodService.ScrapFoodItemsAsync();
        foreach (var item in scrapedFoodItems)
        {
            await _foodService.AddAsync(item);
        }
        return Ok(scrapedFoodItems);
    }
    [HttpGet("search")]
    public async Task<IEnumerable<FoodItemDto?>> GetByName(string name)
    {
        return await _foodService.GetByNameAsync(name);
    }
   

    [HttpGet]
    public async Task<IEnumerable<FoodItemDto?>> GetAll()
    {
        return await _foodService.GetAllAsync();
    }
   [HttpGet("code")]
    public async Task<FoodItemDto?> GetByCode(string code)
    {
        return await _foodService.GetByCodeAsync(code);
    }
   
}
