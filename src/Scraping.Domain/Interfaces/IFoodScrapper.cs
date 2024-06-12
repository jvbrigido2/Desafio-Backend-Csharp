using Scraping.Domain.Entities;

namespace Scraping.Domain.Interfaces;
public interface IFoodScrapper
{
    Task<List<FoodItem>> ScrapFoodItemsAsync();
}
