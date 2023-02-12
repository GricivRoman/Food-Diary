using FoodDiary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task AddEntityAsync<T>(T model)
        {
            await context.AddAsync(model);            
        }
        public void UpdateEntity<T>(T model)
        {
            context.Update(model);

        }
        public void DeleteEntity<T>(T model)
        {
            context.Remove(model);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;            
        }

        public async Task<Product> FindProductByNameAsync(string ProductName)
        {
            var result = await context.Product
               .Where(p => p.ProductName == ProductName).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NullReferenceException("Product was not found");
            }
            else
            {
                return result;
            }
            
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var result = await context.Product.OrderBy(n => n.ProductName).AsNoTracking().ToListAsync();
            
            if (result == null)
            {
                throw new NullReferenceException("Products were not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<Dish> FindDishByNameAsync(string DishName)
        {
           var result = await context.Dish
                .Where(d => d.DishName == DishName).AsNoTracking().FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NullReferenceException("Dish was not found");
            }
            else
            {
                return result;
            }

        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            var result = await context.Dish
                .AsNoTracking()
                .Include(r => r.ResourseSpecification)
                .ThenInclude(c => c.Composition)
                .ThenInclude(p => p.Product)
                .Include(r => r.ResourseSpecification)
                .ThenInclude(v => v.DishValue)
                .AsNoTracking()
                .ToListAsync();

            if (result == null)
            {
                throw new NullReferenceException("Dishes were not found");
            }
            else
            {
                return result;
            }


        }

        public async Task<Dish> FindDishByIdAsync(int dishId)
        {
            var result = await context.Dish.Where(d => d.Id == dishId).AsNoTracking().FirstOrDefaultAsync();
           
            if (result == null)
            {
                throw new NullReferenceException("Dish was not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<User> FindUserByNameAsync(string userName)
        {
            var result = await context.User.Where(n => n.UserName == userName)
                .Include(w => w.WeightConditions.OrderByDescending(d => d.Date))
                .Include(t => t.Targets.OrderByDescending(i => i.Id))
                .ThenInclude(d => d.DailyRate)
                .Include(m => m.Meals)
                .ThenInclude(mi => mi.MealItems)
                .Include(s => s.Sex)
                .Include(p => p.PhysicalActivity)
                .Include(m => m.UserMenu)
                .ThenInclude(d => d.Dishes)
                .ThenInclude(v => v.ResourseSpecification.DishValue)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NullReferenceException("User was not found");
            }
            else
            {
                return result;
            }
        }       

        public async Task<User> FindUserMealsByNameAsync(string userName)
        {
            var result = await context.User.Where(n => n.UserName == userName)
                .Include(m => m.Meals)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            
            if (result == null)
            {
                throw new NullReferenceException("FindUserMeals was not found by user name");
            }
            else
            {
                return result;
            }
        }

        public async Task<IEnumerable<SexCatalog>> GetFullSexCatalogAsync()
        {
            var result = await context.SexCatalog.ToListAsync();
            
            if (result == null)
            {
                throw new NullReferenceException("SexCatalog was not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<IEnumerable<PhysicalActivityCatalog>> GetFullPhysicalActivityCatalogAsync()
        {
            var result = await context.PhysicalActivityCatalog.ToListAsync();
            
            if (result == null)
            {
                throw new NullReferenceException("PhysicalActivityCatalog was not found");
            }
            else
            {
                return result;
            }
        }

        public async Task<Meal> FindMealByIdAsync(int id)
        {
            try
            {
                var result = await context.Meal.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new NullReferenceException("Meal was not found");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {

                logger.LogError($"{ex}");
                throw;
            }
           
            
            
        }

        
    }
}
