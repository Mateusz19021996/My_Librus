using Microsoft.AspNetCore.Authorization;
using MyLibrus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLibrus.Authorization
{

    // tylko student moze sobie zmienic dane kontatkowe
    public class ContactEditHandler : AuthorizationHandler<ContactEdit, Contact>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ContactEdit requirement, Contact contact)
        {
            // sprawdzamy co chce wykonac uzytkownik
            if(requirement.ResourceOperation == ResourceOperation.Read ||
               requirement.ResourceOperation == ResourceOperation.Create)
            {
                // jesli chce tylko odczytac albo stworzyc to kazdy ma do tego prawo
                context.Succeed(requirement);
            }

            // tutaj pobieramy claima z id 
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if(contact.StudentId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
