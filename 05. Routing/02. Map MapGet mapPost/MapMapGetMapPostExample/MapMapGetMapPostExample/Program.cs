var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(endpoints =>
{
    //add your endpoints here
    endpoints.Map("map1", async (context) => {
        await context.Response.WriteAsync("In Map 1");
    });

    //Get
    endpoints.MapGet("map2", async (context) => {
        await context.Response.WriteAsync("In Map 2 Get");
    });

    //Post
    //Below is Post request and we cannot do it on browser use POSTMAN
    endpoints.MapPost("map3", async (context) => {
        await context.Response.WriteAsync("In Map 3 Post");
    });
});

app.Run(async(HttpContext context) =>
{
    await context.Response.WriteAsync($"Request received at path: {context.Request.Path}");
});
app.Run();