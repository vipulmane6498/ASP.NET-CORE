using Microsoft.Extensions.FileProviders;

//if you are using only  wwwroot directory for static files then you dont need to configuration like point 1 i.e. WebApplicationOptions and WebRootPath
//1. but if you want to use another folder to serve as a static directory then need to configure that folder with WebRootPath property within WebAppicationOptions while creating the builder
var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});
var app = builder.Build();



//Enable static file with predefined method UseStaticFiles()
//2. works with web root path (myroot)
app.UseStaticFiles();




//3. if you want to add one more folder to serve as a static directory.then use UseStaticFiles delegate
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")

        )
});

//enable routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("hello !");
    });

});

app.Run();
