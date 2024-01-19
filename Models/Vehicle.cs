namespace Turbo.az.Models;
public class Vehicle
{
    public int Id { get; set; }
    public double? Price { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public int? EngineVolume { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? ManufactureDate { get; set; }
    public int? Mileage { get; set; }
    public int? HorsePower { get; set; }
    public string? Description { get; set; }
}