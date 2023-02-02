using FoodDiary.Data.Entities;

namespace FoodDiary.Data
{
    public interface IMyAppRepository
    {
        public bool SaveAll();
        public Product FindProductByName(string productName);

        public void AddEntity(object model);
        public void UpdateEntity(object model);


        public IEnumerable<Product> GetAllProducts();

        public Dish FindDishByName(string dishName);
        public Dish FindDishById(int dishId);

        public IEnumerable<Dish> GetAllDishes();

        public Task<User> FindUserByNameAsync(string userName);
    }
}