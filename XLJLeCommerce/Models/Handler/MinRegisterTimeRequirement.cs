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
        /// <summary>
        /// handles the requirement, in this case gives permission if a vip member
        /// </summary>
        /// <param name="context">the database</param>
        /// <param name="requirement">the requirement for the policy</param>
        /// <returns></returns>
        protected override  Task HandleRequirementAsync(AuthorizationHandlerContext context, MinRegisterTimeRequirement requirement)
        {
            if (!context.User.HasClaim(u => u.Type == "RegisteredDate") )
            {
                return Task.CompletedTask;
            }

            DateTime dateOfRegister = Convert.ToDateTime(context.User.FindFirst(u => u.Type == "RegisteredDate").Value);

            int Day = DateTime.Today.DayOfYear - dateOfRegister.DayOfYear;
            if (Day >= 1)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
