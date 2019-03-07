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
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIsAdminHandler requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
