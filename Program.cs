using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


// Connection info stored in appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Register the DataContext service
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["Data:NBAStats:ConnectionString"]));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
