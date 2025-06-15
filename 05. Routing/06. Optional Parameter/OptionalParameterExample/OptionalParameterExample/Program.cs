var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();


app.UseEndpoints(endpoints =>
{   
    endpoints.Map("employee/profile/{employeeName?}", async (context) =>
    
    {
        //If employee name is supplied in url execute below code
        if(context.Request.RouteValues.ContainsKey("employeename")){
            string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
            await context.Response.WriteAsync($"Employee name - {employeeName}");
        }
        //if the employeeName is not provided in url it will return null so instead of return null you can add any statement like below
        else
        {
            await context.Response.WriteAsync("Employee Details - employee name is not supplied");
        }
    });

});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("End !");
});

app.Run();