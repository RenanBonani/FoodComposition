using FoodComposition.Application.UseCases;
using FoodComposition.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodComposition.API.Controllers
{
    [Route("api/foodcomposition")]
    [ApiController]
    public class FoodCompositionController : ControllerBase
    {
        private readonly FoodCompositionDbContext _dbContext;

        public FoodCompositionController(FoodCompositionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _dbContext.FoodCompositions.ToListAsync();
            return Ok(data);
        }
        
        [HttpGet("{name}")]        
        public async Task<IActionResult> GetDataByName(string name)
        {
            var data = await _dbContext.FoodCompositions
                .Where(item => item.NameFood.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            return Ok(data);
        }
    }
}