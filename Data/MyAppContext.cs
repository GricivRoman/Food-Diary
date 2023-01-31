using FoodDiary.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.Data
{
    public class MyAppContext : IdentityDbContext<User>
    {
        
        public MyAppContext(DbContextOptions<MyAppContext> options) :base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        
        public DbSet<Product> Product { get; set; }

        public DbSet<Dish> Dish { get; set; }
        public DbSet<DishValue> DishValue { get; set; }
    }
}
