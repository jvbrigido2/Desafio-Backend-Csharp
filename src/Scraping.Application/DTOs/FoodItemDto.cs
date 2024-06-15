namespace Scraping.Application.DTOs;
public class FoodItemDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string ScientificName { get; set; }
    public string Group { get; set; }
    public List<ComponentDto> Components { get; set; }
}
