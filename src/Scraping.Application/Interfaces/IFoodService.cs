using Scraping.Application.DTOs;
using Scraping.Domain.Entities;

namespace Scraping.Application.Interfaces;
public interface IFoodService
{
    Task<IEnumerable<FoodItemDto?>> GetAllAsync();
    Task<IEnumerable<FoodItemDto?>> GetByNameAsync(string name);
    Task<FoodItemDto?> GetByCodeAsync(string code);
    Task AddAsync(FoodItem foodItem);
    Task<List<FoodItem>> ScrapFoodItemsAsync();
}
