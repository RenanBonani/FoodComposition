using AngleSharp;
using FoodComposition.Communication;
using FoodComposition.Infrastructure;

namespace FoodComposition.Application.UseCases.WebScrapping
{
    public class WebScrappingUseCases
    {
        private readonly FoodCompositionDbContext dbContext;

        public WebScrappingUseCases(FoodCompositionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<FoodCompositionItem>> GetDataTable()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var items = new List<FoodCompositionItem>();
            var currentPage = 1;
            var lastPage = 2; // Define a última página

            
            while (currentPage <= lastPage)
            {
                string address = $"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina={currentPage}&atuald={(currentPage / 10) + 1}";
                var document = await context.OpenAsync(address);

                var rows = document.QuerySelectorAll("tr");

                foreach (var row in rows.Skip(1))
                {
                    var cells = row.QuerySelectorAll("td");

                    if (cells.Length >= 5)
                    {
                        var item = new FoodCompositionItem
                        {
                            Code = cells[0].TextContent.Trim(),
                            NameFood = cells[1].TextContent.Trim(),
                            ScientificName = cells[2].TextContent.Trim(),
                            GroupFood = cells[3].TextContent.Trim()
                        };

                        var componentes = await GetComponents(context, item.Code);
                        item.Componentes = componentes;

                        items.Add(item);

                        SaveToDatabase(item).Wait();
                    }
                }

                currentPage++;
            }

            return items;
        }

        private async Task<List<string>> GetComponents(IBrowsingContext context, string code)
        {
            var componentes = new List<string>();

            var address = $"https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto={code}";
            var document = await context.OpenAsync(address);

            var rows = document.QuerySelectorAll("tr");

            foreach (var row in rows.Skip(1))
            {
                var cells = row.QuerySelectorAll("td:nth-child(1)");

                if (cells.Length >= 1)
                {
                    var componente = cells[0].TextContent.Trim();
                    componentes.Add(componente);
                }
            }

            return componentes;
        }

        private async Task SaveToDatabase(FoodCompositionItem item)
        {
            var entity = new Infrastructure.Entities.Composition
            {
                Code = item.Code,
                NameFood = item.NameFood,
                ScientificName = item.ScientificName,
                GroupFood = item.GroupFood,
                Componentes = item.Componentes
            };

            dbContext.FoodCompositions.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
