using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLJLeCommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace XLJLeCommerce.Models
{
    public class RoleInitializer
    {
        /// <summary>
        /// set up admin and member roles
        /// </summary>
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name= ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        /// <summary>
        /// adds roles to identity db
        /// </summary>
        /// <param name="serviceProvider">helper object so can add roles</param>
        public static void SeedData(IServiceProvider serviceProvider)
        {

            // looking at our database
            using (var dbContext = new ApplicationDbcontext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbcontext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        /// <summary>
        /// adds roles to database
        /// </summary>
        /// <param name="context">which database</param>
        private static void AddRoles(ApplicationDbcontext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}
