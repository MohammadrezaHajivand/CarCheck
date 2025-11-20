
using CarCheck.Domain.Core.Entities;

namespace CarCheck.Domain.Core.Contract.Services
{
    public interface IVehicleService
    {
        void Add(Vehicle vehicle);
        Vehicle? GetById(int id);
        List<Vehicle> GetByOwnerId(int ownerId);
        Vehicle? GetByPlate(string plateNumber);
    }
}
