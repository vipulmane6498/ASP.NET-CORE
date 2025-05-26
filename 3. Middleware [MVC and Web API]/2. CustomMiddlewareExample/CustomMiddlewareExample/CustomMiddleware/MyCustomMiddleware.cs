

namespace CustomMiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Logic -> whatever you want to add
            await context.Response.WriteAsync("My Custom Middleware class started...");
            await next(context); //calling next middleware once it gets execute below statement will execute
           
            await context.Response.WriteAsync("End");
        }
    }
}

