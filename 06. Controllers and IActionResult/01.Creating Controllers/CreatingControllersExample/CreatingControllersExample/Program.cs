var builder = WebApplication.CreateBuilder(args);

//4. We need to register all the controller classes as a services using AddControllers() method
builder.Services.AddControllers();

var app = builder.Build();

//5. Enable routing
app.UseRouting();


//6. To Execute all the action methods need to use mapControllers() method.
app.MapControllers();

app.Run();
