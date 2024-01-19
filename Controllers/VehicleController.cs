using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Turbo.az.Dtos;
using Turbo.az.Models;
using Turbo.az.Repositories.Base;

namespace Turbo.az.Controllers;
public class VehicleController : Controller
{
    private readonly IVehicleRepository vehicleRepository;
    public VehicleController(IVehicleRepository vehicleRepository)
    {
        this.vehicleRepository = vehicleRepository;
    }

    [HttpGet]
    [ActionName("Index")]
    public async Task<IActionResult> ShowAllVehicles()
    {
        var vehicles = await this.vehicleRepository.GetAllVehiclesAsync();

        return this.View(model: vehicles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return this.View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]VehicleDto vehicleDto)
    {
        await this.vehicleRepository.InsertVehicleAsync(new Vehicle {
            BrandName = vehicleDto.BrandName,
            ModelName = vehicleDto.ModelName,
            Price = vehicleDto.Price,
            EngineVolume =  vehicleDto.EngineVolume,
            ImageUrl = vehicleDto.ImageUrl,
        });

        return RedirectToAction("Index");
    }
}