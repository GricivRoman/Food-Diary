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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           


        }

        public DbSet<User> User { get; set; }
        public DbSet<UserMenu> UserMenu { get; set; }

        public DbSet<Specification> Specification { get; set; }

        public DbSet<Product> Product { get; set; }
        

        //public DbSet<Dish> Dishes { get; set; }

        //public DbSet<Product> Products { get; set; } -- удалил Entity
        //public DbSet<Order> Orders { get; set; } -- удалил Entity





    }
}
