using System;
using Microsoft.EntityFrameworkCore;
using FoodDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FoodDiary.Data;



namespace FoodDiary
{
	public class Program
	{
		static void Main(string[] args)
		{
            var host = CreateHostBuilder(args).Build();

            //RunSeeding(host);

            host.Run();
                       
        }

        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DbSeeder>();
                seeder.SeedAsync().Wait();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

          
        
    }
}


