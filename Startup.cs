using FoodDiary.Data;
using FoodDiary.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FoodDiary.Services;

namespace FoodDiary
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(_config["ConnectionStrings:MyAppContextDb"]));

            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail= true;
               
            }).AddEntityFrameworkStores<MyAppContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg=>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Token:Issuer"],
                        ValidAudience= _config["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]))
                    };
                });


            services.AddTransient<DbSeeder>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services.AddTransient<IMailService, NullMailService>();

            services.AddScoped<IMyAppRepository, MyAppRepository>();

            services.AddTransient<IDishValueCalculator, DishValueCalculator>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddRazorPages();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
				app.UseDeveloperExceptionPage();
			}
            else
            {
				app.UseExceptionHandler("/Error");
			}
                        

            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });                  
        }
    }
}
