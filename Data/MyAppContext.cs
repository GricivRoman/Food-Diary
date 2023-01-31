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



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity("FoodDiary.Data.Entities.Dish", b =>
            //{
            //    b.HasOne("FoodDiary.Data.Entities.ResourseSpecification", "ResourseSpecification")
            //        .WithOne("Dish")
            //        .HasForeignKey("FoodDiary.Data.Entities.Dish", "ResourseSpecificationId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();

            //    b.Navigation("ResourseSpecification");
            //});



            //modelBuilder.Entity("FoodDiary.Data.Entities.User", b =>
            //{
            //    b.HasOne("FoodDiary.Data.Entities.UserMenu", "UserMenu")
            //        .WithOne("User")
            //        .HasForeignKey("FoodDiary.Data.Entities.User", "UserMenuId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();

            //    b.Navigation("UserMenu");
            //});

            //modelBuilder.Entity("FoodDiary.Data.Entities.ResourseSpecification", b =>
            //{
            //    b.HasOne("FoodDiary.Data.Entities.DishValue", "DishValue")
            //        .WithOne("ResourseSpecification")
            //        .HasForeignKey("FoodDiary.Data.Entities.ResourseSpecification", "DishValueId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();
                    

            //    b.Navigation("DishValue");
            //});


        //}

        public DbSet<User> User { get; set; }
        
        public DbSet<Product> Product { get; set; }

        public DbSet<Dish> Dish { get; set; }
        public DbSet<DishValue> DishValue { get; set; }
    }
}
