using Microsoft.EntityFrameworkCore;
using AcmeCorporation.Data;
using AcmeCorporation.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AcmeCorporationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcmeCorporationContext") ?? throw new InvalidOperationException("Connection string 'AcmeCorporationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataGuid.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();







/*builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});*/   
