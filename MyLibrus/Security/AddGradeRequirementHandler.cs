using Microsoft.AspNetCore.Authorization;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO.AddDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLibrus.Security
{
    public class AddGradeRequirementHandler : AuthorizationHandler<GradeOperationRequirement, AddGradeDTO>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GradeOperationRequirement requirement, AddGradeDTO resource)
        {
            var teacherMainSubject =
                context.User.FindFirst(x => x.Type == "TeacherMainSubject").Value;

            if (resource.Subject == teacherMainSubject)
            {
                context.Succeed(requirement);
            }
            else
            {
                //logger implementation
            }

            return Task.CompletedTask;

            //throw new NotImplementedException();
        }
    }
}
