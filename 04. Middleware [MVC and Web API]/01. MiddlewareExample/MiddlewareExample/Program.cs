var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use()
//Below each middleware perform individual single responsibility.

//Middleware 1
app.Use(async(HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context); //add the "context" -> this contains on which we have to perform the operation in next middleware

});

        
//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello Again");
    //if you dont want to call next middleware then dont use next() method to call next middleware
    await next(context);

});


//Middleware 3
//This Run() middleware is terminating middleware. It ends the pipeline.
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello Again Again");

});

app.Run();

//OUTPUT -> Hello Hello Again Hello Again Again
