using Microsoft.EntityFrameworkCore;
using ScalingLamp.Domain.Persistence;
using ScalingLamp.Domain.Services;
using ScalingLamp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ScalingLampContext>(
    optionsAction => optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    builder => builder.MigrationsAssembly("ScalingLamp")));
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IVariableRepository, VariableRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
