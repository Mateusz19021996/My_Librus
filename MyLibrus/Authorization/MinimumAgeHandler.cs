using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Authorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeAut>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeAut requirement)
        {
            var date = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);

            if(date.AddYears(requirement.MinAge) < DateTime.Now)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
