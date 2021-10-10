using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyLibrus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }




        // context - context of http
        // next - next middleware which we want to invoke 
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // tutaj wywolujemy nastepne middleware, przekazujemy mu kontekst
                await next.Invoke(context);
                //jesli podczas wykonywania bedzie wyjatek to idzie do catch
            }
            catch (NotFoundException e)
            {
                //not found
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                _logger.LogError("Moj prywatny error czy dziala test");

                // 500 - Internal server error
                context.Response.StatusCode = 500;
                //await context.Response.WriteAsync("Something went wrong xd");
                //below code works for swagger 
                //await context.Response.WriteAsJsonAsync("something wrong JSON");
                await context.Response.WriteAsJsonAsync(e.Message);
            }
            
        }
    }
}
