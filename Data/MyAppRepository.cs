using FoodDiary.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.Data
{
    public class MyAppRepository : IMyAppRepository
    {
        private readonly MyAppContext context;
        private readonly ILogger<MyAppRepository> logger;

        public MyAppRepository(MyAppContext context, ILogger<MyAppRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            context.Add(model);
        }
               
        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }

        public Product FindProductByName(string ProductName)
        {
            logger.LogInformation($"{DateTime.UtcNow}: Find product method was started");
            var product = context.Product
                .Where(p => p.ProductName == ProductName).FirstOrDefault();
            
            if (product != null)
            {
                logger.LogInformation($"{DateTime.UtcNow}: The roduct was found");
                return product;
            }
            else
            {
                logger.LogInformation($"{DateTime.UtcNow}: A product wasn't found");
                return null;
            }
            
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Product.OrderBy(n => n.ProductName).ToList();
        }

        public Dish FindDishByName(string DishName)
        {
            logger.LogInformation($"{DateTime.UtcNow}: Find dish method was started");
            var dish = context.Dish
                .Where(d => d.DishName== DishName).FirstOrDefault();

            if (dish != null)
            {
                logger.LogInformation($"{DateTime.UtcNow}: The dish was found");
                return dish;
            }
            else
            {
                logger.LogInformation($"{DateTime.UtcNow}: A dish wasn't found");
                return null;
            }
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return context.Dish
                .Include(r => r.ResourseSpecification)
                .ThenInclude(c => c.Composition)
                .ThenInclude(p => p.Product)
                .Include(r => r.ResourseSpecification)
                .ThenInclude(v => v.DishValue)
                .ToList();
        }
    }
}
