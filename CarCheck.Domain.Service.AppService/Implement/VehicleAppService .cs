using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Application.Services.Implement;

public class VehicleAppService(IVehicleService _vehicleService) : IVehicleAppService
{
    public Vehicle AddVehicle(CreateVehicleDto dto)
    {
        var existing = _vehicleService.GetByPlate(dto.PlateNumber);
        if (existing != null)
            return existing;

        var vehicle = new Vehicle
        {
            PlateNumber = dto.PlateNumber,
            YearOfManufacture = dto.YearOfManufacture,
            ModelId = dto.ModelId,
            OwnerId = dto.OwnerId
        };

        _vehicleService.Add(vehicle);
        return vehicle;
    }

    public Vehicle? GetByPlate(string plateNumber)
    {
        return _vehicleService.GetByPlate(plateNumber);
    }

    public List<Vehicle> GetByOwnerId(int ownerId)
    {
        return _vehicleService.GetByOwnerId(ownerId);
    }
}

