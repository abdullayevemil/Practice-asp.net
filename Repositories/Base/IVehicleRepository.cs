using Turbo.az.Models;

namespace Turbo.az.Repositories.Base;
public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    Task InsertVehicleAsync(Vehicle vehicle);
}