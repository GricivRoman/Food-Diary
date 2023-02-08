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

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;            
        }

        public async Task<Product> FindProductByNameAsync(string ProductName)
        {

            return await context.Product
                .Where(p => p.ProductName == ProductName).FirstOrDefaultAsync();
            

           
            
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await context.Product.OrderBy(n => n.ProductName).ToListAsync();
        }

        public async Task<Dish> FindDishByNameAsync(string DishName)
        {
           
            return await context.Dish
                .Where(d => d.DishName== DishName).FirstOrDefaultAsync();
                        
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {

            return await context.Dish
                .Include(r => r.ResourseSpecification)
                .ThenInclude(c => c.Composition)
                .ThenInclude(p => p.Product)
                .Include(r => r.ResourseSpecification)
                .ThenInclude(v => v.DishValue)
                .ToListAsync();
                
        }

        public async Task<Dish> FindDishByIdAsync(int dishId)
        {
            return await context.Dish.Where(d => d.Id == dishId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> FindUserByNameAsync(string userName)
        {
            
            return await context.User.Where(n => n.UserName == userName)
                .Include(w => w.WeightConditions.OrderByDescending(d=>d.Date))
                .Include(t => t.Targets.OrderByDescending(i => i.Id))
                .ThenInclude(d => d.DailyRate)
                .Include(m => m.Meals)
                .ThenInclude(mi => mi.MealItems)
                .Include(s => s.Sex)
                .Include(p => p.PhysicalActivity)
                .Include(m => m.UserMenu)
                .ThenInclude(d => d.Dishes)
                .ThenInclude(v => v.ResourseSpecification.DishValue)
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SexCatalog>> GetFullSexCatalogAsync()
        {
            return await context.SexCatalog.ToListAsync();
        }

        public async Task<IEnumerable<PhysicalActivityCatalog>> GetFullPhysicalActivityCatalogAsync()
        {
            return await context.PhysicalActivityCatalog.ToListAsync();
        }
    }
}
