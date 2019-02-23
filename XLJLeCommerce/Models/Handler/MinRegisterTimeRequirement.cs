using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace XLJLeCommerce.Models.Handler
{
    public class MinRegisterTimeRequirement : AuthorizationHandler<MinRegisterTimeRequirement>,IAuthorizationRequirement
    {


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinRegisterTimeRequirement requirement)
        {

            DateTime dateOfRegister = Convert.ToDateTime(context.User.FindFirst(u=>u.Type== "RegisteredDate").Value);

            int Day = DateTime.Today.Day- dateOfRegister.Day;
            if (Day >= 1)
            {
                context.Succeed(requirement);

            }

            return Task.CompletedTask;


        }
    }
}
