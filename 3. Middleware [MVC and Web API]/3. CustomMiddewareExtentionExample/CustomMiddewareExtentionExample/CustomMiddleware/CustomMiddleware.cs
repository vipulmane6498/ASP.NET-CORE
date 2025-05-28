
namespace CustomMiddewareExtentionExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("2nd Middleware !\n");
            await next(context);
            await context.Response.WriteAsync("End !\n");

        }
    }

    // To create Custom Middleware Extension, we need to create a static class and method
    // Use IApplicationBuilder as the parameter type in the extension method
    // so it can be called on the 'app' object, which implements IApplicationBuilder
    public static class CustomMiddlewareExtensionExample
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this  IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
