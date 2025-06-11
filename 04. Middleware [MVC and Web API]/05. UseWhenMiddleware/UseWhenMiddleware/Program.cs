var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//UseWhen 
app.UseWhen(
    //1. Below is the if condition -> if the URL contains username then execute below code
    context => context.Request.Query.ContainsKey("username"),

    //2. if above username condition true execute below condition
     app =>
    {
        //Created using Use middleware
        app.Use(async ( context,  next) =>
        {
            await context.Response.WriteAsync("Hello from UseWhen middleware branch !\n");
            await next();
        });
    });

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from  middleware at main chain END !");
 
});
app.Run();

