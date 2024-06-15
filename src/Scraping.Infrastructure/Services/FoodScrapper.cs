using HtmlAgilityPack;
using Scraping.Domain.Entities;
using Scraping.Domain.Interfaces;

namespace Scraping.Infrastructure.Services
{
    public class FoodScrapper : IFoodScrapper
    {
        private readonly string _url = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";
        private readonly string _detailBaseUrl = "https://www.tbca.net.br/base-dados/";

        public async Task<List<FoodItem>> ScrapFoodItemsAsync()
        {
            var web = new HtmlWeb();
            var htmlDoc = await web.LoadFromWebAsync(_url);
           
            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'table') and contains(@class, 'table-striped')]/tbody/tr");

            
            if (nodes == null)
            {
                throw new Exception("Nenhum nó foi encontrado usando o seletor XPath fornecido.");
            }

            var foodItems = new List<FoodItem>();

            foreach (var node in nodes)
            {
                var columns = node.SelectNodes("td");

                if (columns != null && columns.Count >= 4) 
                {
                    var foodItem = new FoodItem
                    {
                        Code = columns[0].InnerText.Trim(),
                        Name = HtmlEntity.DeEntitize(columns[1].InnerText.Trim()),
                        ScientificName = HtmlEntity.DeEntitize(columns[2].InnerText.Trim()),
                        Group = columns[3].InnerText.Trim(),
                        Components = new List<Component>(),
                        DetailUrl = _detailBaseUrl + columns[0].SelectSingleNode(".//a").GetAttributeValue("href", "").Trim()
                    };

                    foodItems.Add(foodItem);
                }
                else
                {
                    System.Console.WriteLine("Número insuficiente de colunas encontradas em um dos nós.");
                }
            }

            foreach (var foodItem in foodItems)
            {
                foodItem.Components = await ScrapFoodComponentsAsync(foodItem.DetailUrl);
            }

            return foodItems;
        }
        private async Task<List<Component>> ScrapFoodComponentsAsync(string url)
        {
            var web = new HtmlWeb();
            var htmlDoc = await web.LoadFromWebAsync(url);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//table[@id='tabela1']/tbody/tr");

            var components = new List<Component>();

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var columns = node.SelectNodes("td");

                    if (columns != null && columns.Count >= 1)
                    {
                        var component = new Component
                        {
                            Name = columns[0].InnerText.Trim(),
                            Unit = columns[1].InnerText.Trim(),
                            ValuePer100g = double.TryParse(columns[2].InnerText.Trim(), out var valuePer100g) ? valuePer100g : 0,
                            StandardDeviation = columns[3].InnerText.Trim(),
                            MinimumValue = columns[4].InnerText.Trim(),
                            MaximumValue = columns[5].InnerText.Trim(),
                            NumberOfDataUsed = columns[6].InnerText.Trim(),
                            References = columns[7].InnerText.Trim(),
                            DataType = columns[8].InnerText.Trim()
                        };

                        components.Add(component);
                    }
                }
            }

            return components;
        }
    }
}
