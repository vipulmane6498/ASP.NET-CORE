using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomConventionalMiddlewareclass.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname")){

               string fullname = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];
               await httpContext.Response.WriteAsync(fullname);
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomConventionalMiddleware>();
        }
    }
}
