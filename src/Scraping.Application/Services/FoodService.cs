using Scraping.Domain.Entities;
using Scraping.Domain.Interfaces;
using Scraping.Infrastructure.Data;
using Scraping.Infrastructure.Services;

namespace Scraping.Application.Services;
public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly IFoodScrapper _foodScrapper;

    public FoodService(IFoodRepository foodRepository, IFoodScrapper foodScrapper)
    {
        _foodRepository = foodRepository;
        _foodScrapper = foodScrapper;
    }

    public async Task AddAsync(FoodItem foodItem)
    {
        await _foodRepository.AddAsync(foodItem);
    }

    public async Task<IEnumerable<FoodItem>> GetAllAsync()
    {
        return await _foodRepository.GetAllAsync();
    }

    public async Task<IEnumerable<FoodItem>> GetByNameAsync(string name)
    {
        return await _foodRepository.GetByNameAsync(name);
    }

    public async Task<List<FoodItem>> ScrapFoodItemsAsync()
    {
        return await _foodScrapper.ScrapFoodItemsAsync();
    }
}
