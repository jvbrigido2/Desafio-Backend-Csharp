using Scraping.Domain.Entities;

namespace Scraping.Domain.Interfaces;
public interface IFoodService
{
    Task<IEnumerable<FoodItem>> GetAllAsync();
    Task AddAsync(FoodItem foodItem);
    Task<IEnumerable<FoodItem>> GetByNameAsync(string name);
    Task<List<FoodItem>> ScrapFoodItemsAsync();
}
