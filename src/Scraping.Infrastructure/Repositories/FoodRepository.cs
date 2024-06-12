using Microsoft.EntityFrameworkCore;
using Scraping.Domain.Entities;
using Scraping.Domain.Interfaces;
using Scraping.Infrastructure.Data;

namespace Scraping.Infrastructure.Repositories;
public class FoodRepository : IFoodRepository
{
    private readonly DataContext _context;

    public FoodRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(FoodItem foodItem)
    {
        await _context.FoodItems.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FoodItem>> GetAllAsync()
    {
        return await _context.FoodItems.Include(f => f.Components).ToListAsync();
    }

    public async Task<IEnumerable<FoodItem>> GetByNameAsync(string name)
    {
        return await _context.FoodItems
                .Include(f => f.Components)
                .Where(f => f.Name.Contains(name))
                .ToListAsync();
    }


}
