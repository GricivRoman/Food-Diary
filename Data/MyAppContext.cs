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

            //modelBuilder.Entity<Specification>()
            //    .HasOne(a => a.DishValue)
            //    .WithOne(a => a.Specification)
            //    .HasForeignKey<DishValue>(c => c.SpecificationId);

            

            
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Dish> Dishes { get; set; }

        //public DbSet<Product> Products { get; set; } -- удалил Entity
        //public DbSet<Order> Orders { get; set; } -- удалил Entity





    }
}
