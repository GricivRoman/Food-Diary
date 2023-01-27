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
            if (repository.FindDishByName(model.DishName) != null)
            { 
                return BadRequest("Блюдо с таким именем уже существует");
            }
            else
            {
                
                var composition = new List<CompositionItemViewModel>();

                foreach (var item in model.ResourseSpecification.Composition)
                {
                    var product = mapper.Map<ProductViewModel>(repository.FindProductByName(item.Product.ProductName));
                    if (product == null)
                    {
                        return BadRequest("Имя одного или нескольких продуктов введены некорректно");
                    }
                    else
                    {
                        composition.Add(new CompositionItemViewModel()
                        {
                            Product = product,
                            ProductWeightG = item.ProductWeightG
                        });
                    }
                }

                model.ResourseSpecification.Composition = composition;

                var inputNutritionValue = (from i in composition
                                           select new
                                           {
                                               Calories = (double)(i.Product.Calories * i.ProductWeightG / 100),
                                               Protein = (double)(i.Product.Protein * i.ProductWeightG / 100),
                                               Fat = (double)(i.Product.Fat * i.ProductWeightG / 100),
                                               Carbohydrate = (double)(i.Product.Carbohydrate * i.ProductWeightG / 100)
                                           });


                DishValueViewModel dishValue = new DishValueViewModel()
                {
                    Calories = Math.Round((from i in inputNutritionValue select i.Calories).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                    Protein = Math.Round((from i in inputNutritionValue select i.Protein).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                    Fat = Math.Round((from i in inputNutritionValue select i.Fat).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                    Carbohydrate = Math.Round((from i in inputNutritionValue select i.Carbohydrate).Sum() / (double)model.ResourseSpecification.OutputDishWeightG * 100, 2),
                };

                model.ResourseSpecification.DishValue = dishValue;

                //Далее на страницах через формы будут формироваться сразу уже готовые объекты, можно будет просто маппить. Хотя с dishValue не уверен

                var dish = mapper.Map<Dish>(model);

                repository.AddEntity(dish);
                repository.SaveAll();

                return Created("", mapper.Map<DishViewModel>(dish));
                
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
