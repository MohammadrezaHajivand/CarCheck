using CarCheck.Domain.Core.Entities;

namespace CarCheck.Domain.Core.Contract.Repositories
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        Vehicle? GetById(int id);
        List<Vehicle> GetByOwnerId(int ownerId);
        Vehicle? GetByPlate(string plateNumber);
    }


}
