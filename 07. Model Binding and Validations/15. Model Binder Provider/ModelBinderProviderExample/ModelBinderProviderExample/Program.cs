using ModelBinderProviderExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

//Add PersonModelBinder class as a service to use as a global Binder provider for PersonModelBinder class at 0th index
//so that before excuting inbuilt Model binder this Custom Model Binder Provider will execute
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});


builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();   


app.Run();
