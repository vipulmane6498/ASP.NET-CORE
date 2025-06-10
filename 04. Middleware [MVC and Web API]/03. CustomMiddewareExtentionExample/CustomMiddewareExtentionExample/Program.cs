
using CustomMiddewareExtentionExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.Use(async(HttpContext context, RequestDelegate next ) =>
{
    await context.Response.WriteAsync("1st Middleware !\n");
    await next(context);

});


app.UseMyCustomMiddleware();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("3rd Middleware !\n");
   

});

app.Run();
