using JobPortalApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using JobPortalApp.Model;

namespace JobPortalApp.Data
{

    public class DataGenerator
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserContext(
                serviceProvider.GetRequiredService<DbContextOptions<UserContext>>()))
            {
                if (context.Users.Any())
                {
                    return; // Data was already seeded
                }

                //Adding Default user
                var products = new List<User>
                {
                    new User()
                    {
                        
                        Name = "Andy"                       
                    }
                };


                context.Users.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}