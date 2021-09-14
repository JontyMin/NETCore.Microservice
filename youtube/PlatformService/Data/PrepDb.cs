using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(context: serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new ArgumentNullException());
        }

        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="context"></param>
        public static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                System.Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Misrosoft", Cost = "Free" },
                    new Platform() { Name = "Sql Server Express", Publisher = "Misrosoft", Cost = "Free" },
                    new Platform() { Name = "kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
                context.SaveChanges();

            }
            else
            {
                System.Console.WriteLine("--> We already have data");
            }

        }
    }
}