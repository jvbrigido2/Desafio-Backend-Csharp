using Scraping.Domain.Entities;

namespace Scraping.Domain.Interfaces;
public interface IFoodRepository
{
    Task<IEnumerable<FoodItem>> GetAllAsync();
    Task<IEnumerable<FoodItem>> GetByNameAsync(string name);
    Task<FoodItem?> GetByCodeAsync(string code);

    Task AddAsync(FoodItem foodItem);
}
