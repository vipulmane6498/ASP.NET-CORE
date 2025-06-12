var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//This example does not have output. It is just to understand the syntax.

//1. Enable Routing
app.UseRouting();


//2. Create Endpoint
app.UseEndpoints(endpoints =>
{
    //3. add your endpoints here
});

app.Run();