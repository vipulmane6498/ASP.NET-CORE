var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//1. 
//We are using this Use() and GetEndpoint() method before UseRounting() method hence it will return null
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n"); //OUTPUT-> NULL
    }
    await next(context);
});

//enable routing
app.UseRouting();


//2.
//but if we use this Use() and GetEndpoint() method after useRouting() method hence it will execute
//and if we enter map1 in URL it will give the information of that get request
////i.e. ->
//Endpoint:type of  Protocal ->  http
//type of http request -> get
// and enpoint -> map1
//It will only execute map1 because in map1 we did not added next method.
//so becially getEndpoint() help us the give more information of endpoint we can use to investigate if we face any error
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n"); //OUTPUT : 
    }

    await next(context);
});

//creating endpoints
app.UseEndpoints(endpoints =>
{
    //add your endpoints here
    endpoints.MapGet("map1", async (context) => {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.MapPost("map2", async (context) => {
        await context.Response.WriteAsync("In Map 2");
    });
});

app.Run(async context => {
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();