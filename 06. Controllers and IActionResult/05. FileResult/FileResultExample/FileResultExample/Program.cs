var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();

//Enable staticFiles to interact with static file
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
