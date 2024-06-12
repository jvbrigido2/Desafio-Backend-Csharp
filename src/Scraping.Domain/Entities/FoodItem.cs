namespace Scraping.Domain.Entities;
public class FoodItem
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ScientificName { get; set; } = null!;
    public string Group { get; set; } = null!;
    public List<Component> Components { get; set; } = new List<Component>();

    public string DetailUrl { get; set; } = null!;
}
