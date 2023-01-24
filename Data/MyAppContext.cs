using FoodDiary.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.Data
{
    public class MyAppContext : IdentityDbContext<User>
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) :base(options)
        {

        }

        //public DbSet<Product> Products { get; set; } -- удалил Entity
        //public DbSet<Order> Orders { get; set; } -- удалил Entity


       

       
    }
}
