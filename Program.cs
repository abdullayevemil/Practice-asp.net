using Turbo.az.Middlewares;
using Turbo.az.Repositories;
using Turbo.az.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<LogMiddleware>();

builder.Services.AddSingleton<IVehicleRepository>(provider => 
{
    string connectionStringName = "VehiclesDb";

    string? connectionString = builder.Configuration.GetConnectionString(connectionStringName);

    if (string.IsNullOrEmpty(connectionString) || string.IsNullOrWhiteSpace(connectionString)) 
    {
        throw new Exception($"connection string {connectionStringName} not found in setting.json");
    }

    return new VehicleSqlRepository(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();