using FoodComposition.Application.UseCases.WebScrapping;
using FoodComposition.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FoodComposition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebScrappingFoodCompositionController : ControllerBase
    {
        private readonly FoodCompositionDbContext _dbContext;

        public WebScrappingFoodCompositionController(FoodCompositionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> WebScrapping()
        {
            var useCase = new WebScrappingUseCases(_dbContext);
            var response = await useCase.GetDataTable();

            return Ok();
        }
    }
}
