using AutoMapper;
using Scraping.Application.DTOs;
using Scraping.Application.Interfaces;
using Scraping.Domain.Entities;
using Scraping.Domain.Interfaces;

namespace Scraping.Application.Services;
public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly IFoodScrapper _foodScrapper;
    private readonly IMapper _mapper;

    public FoodService(IFoodRepository foodRepository, IFoodScrapper foodScrapper, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _foodScrapper = foodScrapper;
        _mapper = mapper;
    }

    public async Task AddAsync(FoodItem foodItem)
    {
        await _foodRepository.AddAsync(foodItem);
    }
   
    public async Task<IEnumerable<FoodItemDto?>> GetAllAsync()
    {
        var foodItems = await _foodRepository.GetAllAsync();
        return _mapper.Map<List<FoodItemDto?>>(foodItems);
    }

    public async Task<IEnumerable<FoodItemDto?>> GetByNameAsync(string name)
    {
        var foodItem = await _foodRepository.GetByNameAsync(name);
        return _mapper.Map<List<FoodItemDto?>>(foodItem);
    }

     public async Task<FoodItemDto?> GetByCodeAsync(string code)
     {
        var foodItem = await _foodRepository.GetByCodeAsync(code);
         return _mapper.Map<FoodItemDto?>(foodItem);
     }
     public async Task<List<FoodItem>> ScrapFoodItemsAsync()
     {
         return await _foodScrapper.ScrapFoodItemsAsync();
     }
}
