    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    app.UseRouting();


    app.UseEndpoints(endpoints =>
    {   //We defined vipul as a default value in route parameter
        endpoints.Map("employee/profile/{employeeName=vipul}", async (context) =>
        {
            string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
            await context.Response.WriteAsync($"Employee name - {employeeName}");
        });

    });

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("End !");
    });

    app.Run();
