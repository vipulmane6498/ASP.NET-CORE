
using CustomMiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();


//1st Middleware
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.WriteAsync(" 1st middleware called !");
    await next(context);
});

//2nd Middleware -> CustomMiddleware
app.UseMiddleware<MyCustomMiddleware>();



//3rd Middleware 
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.WriteAsync(" 3rd middleware called !");
    //await next(context);
});



app.Run();
