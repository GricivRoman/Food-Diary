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

            
            host.Run();
                       
        }
               
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

          
        
    }
}


