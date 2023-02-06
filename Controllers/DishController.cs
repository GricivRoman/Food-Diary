using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.Data;
using FoodDiary.Data.Entities;
using AutoMapper;
using System.Text.RegularExpressions;
using FoodDiary.Services;
using FoodDiary.ViewModels.Food;

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
        private readonly IDishValueCalculatorService dishValueCalculator;

        public DishController(IMyAppRepository repository, 
            ILogger<DishController> logger,
            IMapper mapper,
            IDishValueCalculatorService dishValueCalculator)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.dishValueCalculator = dishValueCalculator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = repository.GetAllDishes();

                return Ok(mapper.Map<List<DishViewModel>>(result));
            }
            catch
            {

                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]DishViewModel model)
        {
            if (repository.FindDishByName(model.DishName) != null)
            { 
                return BadRequest("Блюдо с таким именем уже существует");
            }
            else
            {
                model.ResourseSpecification.DishValue = dishValueCalculator.CalculateDishValue(model.ResourseSpecification);
                var dish = mapper.Map<Dish>(model);

                repository.AddEntity(dish);
                repository.SaveAll();

                return Created("", mapper.Map<DishViewModel>(dish));
                
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]DishViewModel model)
        {
            Dish dishToUpdate = repository.FindDishById(model.Id);
                        
            model.ResourseSpecification.DishValue = dishValueCalculator.CalculateDishValue(model.ResourseSpecification);


            dishToUpdate = mapper.Map<Dish>(model);


            repository.UpdateEntity(dishToUpdate);
            repository.SaveAll();

            return Created("", mapper.Map<DishViewModel>(dishToUpdate));
        }

       
    }
}
