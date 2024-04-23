using Microsoft.EntityFrameworkCore;
using web_app.Models;
using web_app.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add DB Context
var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
string connectionString = config["ConnectionString"];
builder.Services.AddDbContext<DbPosManagementContext>(options => options.UseSqlServer(GetConfig.AppSetting["ConnectionString:Default"]));

var app = builder.Build();

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
