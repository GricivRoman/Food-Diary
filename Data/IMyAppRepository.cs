using FoodDiary.Data.Entities;

namespace FoodDiary.Data
{
    public interface IMyAppRepository
    {
        public Task<bool> SaveAllAsync();
        public Task AddEntityAsync<T>(T model);
        public void UpdateEntity<T>(T model);
        public Task<Product> FindProductByNameAsync(string productName);    

        public Task<IEnumerable<Product>> GetAllProductsAsync();

        public Task<Dish> FindDishByNameAsync(string dishName);
        public Task<Dish> FindDishByIdAsync(int dishId);

        public Task<IEnumerable<Dish>> GetAllDishesAsync();

        public Task<User> FindUserByNameAsync(string userName);
    }
}