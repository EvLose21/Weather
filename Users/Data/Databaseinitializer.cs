﻿using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Users.Entities;

namespace Users.Data
{
    public static class Databaseinitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<ApplicationUser>>();


            var user = new ApplicationUser
            {
                UserName = "User",
                LastName = "LastName",
                FirstName = "FirstName"
            };

            var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
            }


            //context.Users.Add(user);
            //context.SaveChanges();
        }
    }
}