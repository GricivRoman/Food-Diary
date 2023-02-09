using AutoMapper;
using FoodDiary.Data;
using FoodDiary.ViewModels.Food;
using FoodDiary.ViewModels.User;

namespace FoodDiary.Services.EnergyValueCalculator
{
    public class EnergyValueCalculatorService : IEnergyValueCalculatorService
    {
        private readonly IMyAppRepository repository;
        private readonly IMapper mapper;

        public EnergyValueCalculatorService(IMyAppRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification)
        {
            var inputNutritionValue = from i in resourseSpecification.Composition
                                      select new
                                      {
                                          Calories = (double)(i.Product.Calories * i.ProductWeightG / 100),
                                          Protein = (double)(i.Product.Protein * i.ProductWeightG / 100),
                                          Fat = (double)(i.Product.Fat * i.ProductWeightG / 100),
                                          Carbohydrate = (double)(i.Product.Carbohydrate * i.ProductWeightG / 100)
                                      };


            DishValueViewModel dishValue = new DishValueViewModel()
            {
                Id = resourseSpecification.DishValue.Id,
                Calories = Math.Round((from i in inputNutritionValue select i.Calories).Sum() / (double)resourseSpecification.OutputDishWeightG * 100, 2),
                Protein = Math.Round((from i in inputNutritionValue select i.Protein).Sum() / (double)resourseSpecification.OutputDishWeightG * 100, 2),
                Fat = Math.Round((from i in inputNutritionValue select i.Fat).Sum() / (double)resourseSpecification.OutputDishWeightG * 100, 2),
                Carbohydrate = Math.Round((from i in inputNutritionValue select i.Carbohydrate).Sum() / (double)resourseSpecification.OutputDishWeightG * 100, 2),
            };

            return dishValue;
        }

        private MealValueViewModel CalculateMealValue(MealViewModel meal)
        {
            


            var inputNutritionValue = from i in meal.MealItems                                      
                                      select new
                                      {
                                          Calories = (double)(i.Dish.ResourseSpecification.DishValue.Calories * i.DishWeightG / 100),
                                          Protein = (double)(i.Dish.ResourseSpecification.DishValue.Protein * i.DishWeightG / 100),
                                          Fat = (double)(i.Dish.ResourseSpecification.DishValue.Fat * i.DishWeightG / 100),
                                          Carbohydrate = (double)(i.Dish.ResourseSpecification.DishValue.Carbohydrate * i.DishWeightG / 100)
                                      };

            MealValueViewModel mealValue = new MealValueViewModel
            {
                Calories = Math.Round((from i in inputNutritionValue select i.Calories).Sum(),2),
                Protein = Math.Round((from i in inputNutritionValue select i.Protein).Sum(),2),
                Fat = Math.Round((from i in inputNutritionValue select i.Fat).Sum(), 2),
                Carbohydrate = Math.Round((from i in inputNutritionValue select i.Carbohydrate).Sum(), 2)
            };

            return mealValue;
        }

        public async Task<ICollection<MealViewModel>> GetMealsWithValueAsync(ICollection<MealViewModel> meals)
        {            
            var dishes = mapper.Map<List<DishViewModel>>(await repository.GetAllDishesAsync());
            
            foreach (var meal in meals)
            {
                foreach (var item in meal.MealItems)
                {
                    item.Dish = dishes.Where(i => i.Id == item.DishId).FirstOrDefault();
                }

                meal.MealValue = CalculateMealValue(meal);
            }

            return meals;
        }

    }
}
