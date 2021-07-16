using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware // we need to add it to tell ASP that this class is middleware
    {

        public ErrorHandlingMiddleware()
        {

        }
        //next - access to next middleware
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context); // here we call next middleware?
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
