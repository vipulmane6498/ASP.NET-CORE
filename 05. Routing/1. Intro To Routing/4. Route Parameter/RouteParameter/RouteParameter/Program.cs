var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extention}", async (context) =>
    {
        string fileName = Convert.ToString(context.Request.RouteValues["filename"]); //get file name and convert it into string and store in fileName variable
        string extentions = Convert.ToString(context.Request.RouteValues["extention"]);  ////get extention and convert it into string and store in extentions variable


        //Show in output -> e.g. In files - hello - txt
        await context.Response.WriteAsync($"In files - {fileName} - {extentions}");  
    });


    endpoints.Map("employee/profile/{employeename}",async (context) =>
    {
            string employeeName= Convert.ToString(context.Request.RouteValues["employeename"]); //get employeename and convert it into string and store in employeeName variable

        //Show in output -> e.g. In Employee - John
        await context.Response.WriteAsync($"In Employee: {employeeName}");
    });
});





app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request recieved at: {context.Request.Path}");
});
app.Run();
