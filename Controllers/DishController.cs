using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.Data;
using FoodDiary.Data.Entities;
using AutoMapper;
using System.Text.RegularExpressions;
using FoodDiary.ViewModels.Food;
using FoodDiary.Services.EnergyValueCalculator;

namespace FoodDiary.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DishController : Controller
    {
        private readonly IMyAppRepository repository;
        private readonly ILogger<DishController> logger;
        private readonly IMapper mapper;
        private readonly IEnergyValueCalculatorService dishValueCalculator;

        public DishController(IMyAppRepository repository, 
            ILogger<DishController> logger,
            IMapper mapper,
            IEnergyValueCalculatorService dishValueCalculator)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishValueCalculator = dishValueCalculator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await repository.GetAllDishesAsync();

                return Ok(mapper.Map<List<DishViewModel>>(result));
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DishViewModel model)
        {
            try
            {
                await repository.FindDishByNameAsync(model.DishName);
                return BadRequest("Блюдо с таким именем уже существует");

            }
            catch
            {
                model.ResourseSpecification.DishValue = dishValueCalculator.CalculateDishValue(model.ResourseSpecification);
                var dish = mapper.Map<Dish>(model);

                await repository.AddEntityAsync(dish);
                await repository.SaveAllAsync();

                return Created("", mapper.Map<DishViewModel>(dish));
            }    
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]DishViewModel model)
        {
            Dish dishToUpdate = await repository.FindDishByIdAsync(model.Id);
                        
            model.ResourseSpecification.DishValue = dishValueCalculator.CalculateDishValue(model.ResourseSpecification);

            dishToUpdate = mapper.Map<Dish>(model);

            repository.UpdateEntity(dishToUpdate);
            await repository.SaveAllAsync();

            return Created("", mapper.Map<DishViewModel>(dishToUpdate));
        }       
    }
}
