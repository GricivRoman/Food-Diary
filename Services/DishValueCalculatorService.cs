using FoodDiary.ViewModels;

namespace FoodDiary.Services
{
    public class DishValueCalculatorService : IDishValueCalculatorService
    {
        public DishValueViewModel CalculateDishValue(ResourseSpecificationViewModel resourseSpecification)
        {
            var inputNutritionValue = (from i in resourseSpecification.Composition
                                       select new
                                       {
                                           Calories = (double)(i.Product.Calories * i.ProductWeightG / 100),
                                           Protein = (double)(i.Product.Protein * i.ProductWeightG / 100),
                                           Fat = (double)(i.Product.Fat * i.ProductWeightG / 100),
                                           Carbohydrate = (double)(i.Product.Carbohydrate * i.ProductWeightG / 100)
                                       });


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

    }
}
