using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Handler
{
    public class UserIsAdminHandler : AuthorizationHandler<UserIsAdminHandler>, IAuthorizationRequirement
    {
        /// <summary>
        /// handles a requirement, in this care if they are admin
        /// </summary>
        /// <param name="context">the databasse</param>
        /// <param name="requirement">the requirement</param>
        /// <returns>succeed or just complete</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIsAdminHandler requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(ApplicationRoles.Admin))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
