using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Application.Services.Interfaces
{
    public interface IVehicleAppService
    {
        Vehicle AddVehicle(CreateVehicleDto dto);
        Vehicle? GetByPlate(string plateNumber);
        List<Vehicle> GetByOwnerId(int ownerId);
    }


}
