namespace Scraping.Application.DTOs;
public class ComponentDto
{
    public string Name { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public double ValuePer100g { get; set; }
    public string? StandardDeviation { get; set; }
    public string? MinimumValue { get; set; }
    public string? MaximumValue { get; set; }
    public string? NumberOfDataUsed { get; set; }
    public string? References { get; set; }
    public string DataType { get; set; } = null!;
}
