using FoodDiary.Data.Entities;

namespace FoodDiary.Data
{
    public interface IMyAppRepository
    {
        public bool SaveAll();
        public Product FindProductByName(string ProductName);

        void AddEntity(object model);
        
        public IEnumerable<Product> GetAllProducts();

        public Dish FindDishByName(string DishName);

        public IEnumerable<Dish> GetAllDishes();
    }
}