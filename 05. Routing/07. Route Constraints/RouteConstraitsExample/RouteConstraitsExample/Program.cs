var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //1. datetime constraint
    //daily-Digest-Report/{reportdate}
    endpoints.Map("daily-Digest-Report/{reportdate:datetime}", async(context) =>
    {
      DateTime?  reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
       await context.Response.WriteAsync($"In Daily-Digest-Report - {reportDate.ToString()}"); //OUTPUT -> In Daily-Digest-Report - 15-01-2016 00:00:00
    });

    //2. Guid constraint -> to generate unique value each time - unlimited
    //E.g. cities/cityId
    endpoints.Map(  "cities/{citiId:guid}", async(context) =>
    {
       Guid citiId= Guid.Parse(Convert.ToString(context.Request.RouteValues["citiId"]));
        await context.Response.WriteAsync($"City Information - {citiId}");
    });


    //3. length(min, max) for string-> it will accept the give range of character for string
    //always first add constraints then default value
    //Eg: employee/profile/John
    endpoints.Map("employee/profile/{Employeename:length(4,7):alpha=Vipul}", async (context) =>
    {
           string? employeeName = Convert.ToString(context.Request.RouteValues["Employeename"]);
           await context.Response.WriteAsync($"Employee details - {employeeName}");
    });

    //4. Regex -> match with the string that matches the specified regular expression
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(jan|oct|sept)$)}", async (context) =>
    {
          int year = Convert.ToInt32(context.Request.RouteValues["year"]);
          string month =  Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "jan" || month == "oct" || month == "sept")
        {
            await context.Response.WriteAsync($"Sales Report -> {year}-{month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for sales report");
        }
    });
});


app.Run(async context => {
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});

app.Run();
