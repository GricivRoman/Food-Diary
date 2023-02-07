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
using FoodDiary.Services.UserTargetDailyRateCalculator;
using FoodDiary.Services.UserTargetDailyRateCalculator.BodyTypeFactoryBuilder;
using FoodDiary.Middlewares;

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
            services.AddTransient<IUserCreaterService, UserCreaterService>();

            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail= true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireNonAlphanumeric = false;

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


            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services.AddTransient<IMailService, NullMailService>();


            services.AddScoped<IMyAppRepository, MyAppRepository>();

            services.AddTransient<IDishValueCalculatorService, DishValueCalculatorService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddRazorPages();
            services.AddTransient<IUserDailyRateCalculator, UserDailyRateCalculator>();

            services.AddTransient<IBodyTypeBuilder, BodyTypeBuilder>();
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
            app.UseMiddleware<ExceptionHandlingMiddleware>();

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
