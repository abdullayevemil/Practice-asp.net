using System.Data.SqlClient;
using Dapper;
using Turbo.az.Models;
using Turbo.az.Repositories.Base;

namespace Turbo.az.Repositories;
public class VehicleSqlRepository : IVehicleRepository
{
    private readonly string connectionString;

    public VehicleSqlRepository(string connectionString) => this.connectionString = connectionString;

    public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
    {
        using var connection = new SqlConnection(connectionString);

        var vehicles = await connection.QueryAsync<Vehicle>("select * from Vehicles");

        return vehicles;
    }

    public async Task InsertVehicleAsync(Vehicle vehicle) 
    {
        using var connection = new SqlConnection(connectionString);

        var vehicles = await connection.ExecuteAsync(
            sql: "insert into Vehicles (BrandName, ModelName, Price, EngineVolume, ImageUrl, ManufactureDate, Mileage, HorsePower, Description) values (@BrandName, @ModelName, @Price, @EngineVolume, @ImageUrl, @ManufactureDate, @Mileage, @HorsePower, @Description);",
            param: vehicle);
    }
}