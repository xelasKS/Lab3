var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.Run();