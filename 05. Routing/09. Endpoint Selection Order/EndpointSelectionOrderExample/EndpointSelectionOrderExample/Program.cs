using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
        //sales-report/2024/jan
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async(context)=>
        {
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

    //below example has more fixed/literal segments then above
    endpoints.Map("sales-report/{year:int:min(1900)}/jan", async context =>
    {

        await context.Response.WriteAsync("Sales report exclusively for 2024 - jan -> as it has more segments");
    });
});

app.Run();
