using exceptionhandlers.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using IExceptionHandler = exceptionhandlers.handlers.IExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.AddExceptionHandlers();
builder.Services.AddControllers();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseExceptionHandler();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();