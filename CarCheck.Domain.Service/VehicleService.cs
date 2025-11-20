using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Service.Service
{
    public class VehicleService(IVehicleRepository context) : IVehicleService
    {
        public void Add(Vehicle vehicle)
        {
            context.Add(vehicle);
        }

        public Vehicle? GetById(int id)
        {
            return context.GetById(id);
        }

        public List<Vehicle> GetByOwnerId(int ownerId)
        {
            return context.GetByOwnerId(ownerId);
        }

        public Vehicle? GetByPlate(string plateNumber)
        {
            return context.GetByPlate(plateNumber);
        }
    }
}
