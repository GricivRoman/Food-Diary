using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FoodDiary.ViewModels;
using FoodDiary.Data;
using FoodDiary.Data.Entities;
using AutoMapper;
using System.Text.RegularExpressions;


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

        public DishController(IMyAppRepository repository, ILogger<DishController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post([FromBody]DishViewModel model)
        {

            var composition = new List<CompositionItem>();

            foreach (var item in model.ResourseSpecification.Composition)
            {
                var product = repository.FindProductByName(item.Product.ProductName);
                if (product == null)
                {
                    return BadRequest("Имя одного или нескольких продуктов введены некорректно");
                }
                else
                {
                    composition.Add(new CompositionItem()
                    {
                        Product = product,
                        ProductWeightG = item.ProductWeightG
                    });
                }
            }

            var inputNutritionValue  = (from i in composition
                     select new
                     {
                         Calories = (i.Product.Calories * i.ProductWeightG / 100),
                         Protein = (i.Product.Protein * i.ProductWeightG / 100),
                         Fat = (i.Product.Fat * i.ProductWeightG / 100),
                         Carbohydrate = (i.Product.Carbohydrate * i.ProductWeightG / 100)
                     });


            if (repository.FindDishByName(model.DishName) != null)
            { 
                return BadRequest("Блюдо с таким именем уже существует");
            }
            else
            {
                var dish = new Dish()
                {
                    DishName = model.DishName,
                    ResourseSpecification = new ResourseSpecification()
                    {
                        Composition = composition,

                        OutputDishWeightG = model.ResourseSpecification.OutputDishWeightG,

                        DishValue = new DishValue()
                        {
                            Calories = Math.Round((from i in inputNutritionValue select i.Calories).Sum() / (double)model.ResourseSpecification.OutputDishWeightG *100,2),
                            Protein = Math.Round((from i in inputNutritionValue select i.Protein).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                            Fat = Math.Round((from i in inputNutritionValue select i.Fat).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                            Carbohydrate = Math.Round((from i in inputNutritionValue select i.Carbohydrate).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                        }
                    }
                };

                repository.AddEntity(dish);
                repository.SaveAll();

                return Created("", mapper.Map<DishViewModel>(dish));
                //return Created("", dish);
            }
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
    }
}
