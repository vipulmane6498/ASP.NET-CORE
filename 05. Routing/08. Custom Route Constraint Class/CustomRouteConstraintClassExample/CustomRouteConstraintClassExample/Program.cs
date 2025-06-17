//5. import the namespace 
using CustomRouteConstraintClassExample.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);

//6. Its the custom constraint hence need to register it in a builder ->Add Constraint to the builder
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthCustomConstraint));  //month -> user defined name for constraint, name of the constraint.
                                                                         //We can you this name multiply times whenever needed so that we can use custom constraint class.
                                                                         //MonthCustomConstraint -> it is class that we need to add in builder with user defined constraint
});
var app = builder.Build();
//7.Enable Routing
app.UseRouting();

//8. add endpoint
app.UseEndpoints(endpoints =>
{
    //9. use Months as Custom constraint here instead of regex
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async (context)=>{

      string? year = Convert.ToString( context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"sales report: {year}-{month}");
    });

});
/*
     endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>{

        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for sales report");
        }
    });
*/
app.Run(async context => {
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});
app.Run();
