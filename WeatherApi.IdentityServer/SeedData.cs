using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WeatherApi.Library.Data;
using WeatherApi.Library.UserManagementService.Models;

namespace WeatherApi.IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UsersDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UsersDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var aleks = userMgr.FindByNameAsync("aleks").Result;
                    if (aleks == null)
                    {
                        aleks = new ApplicationUser
                        {
                            UserName = "aleks",
                            FirstName = "Aleksandr",
                            LastName = "Losev",
                            Email = "weatherapi.team@gmail.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(aleks, "Pass_123").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(aleks, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Aleksandr Losev"),
                            new Claim(JwtClaimTypes.GivenName, "Aleksandr"),
                            new Claim(JwtClaimTypes.FamilyName, "Losev"),
                            new Claim(JwtClaimTypes.WebSite, "https://github.com/EvLose21/"),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("Aleksandr has been created");
                    }
                    else
                    {
                        Log.Debug("Aleksandr already exists");

                        var result = userMgr.UpdateAsync(aleks).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("Aleksandr has been updated");
                    }
                }
            }
        }
    }
}
