using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Entities;
using CarCheck.Infrastructure.EFCore.Persistence;


namespace CarCheck.Infrastructure.EFCore.Repositories
{
    public class VehicleRepository(CarCheckDbContext _context) : IVehicleRepository
    {
        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public Vehicle? GetById(int id)
        {
            return _context.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public List<Vehicle> GetByOwnerId(int ownerId)
        {
            return _context.Vehicles
                .Where(v => v.OwnerId == ownerId)
                .ToList();
        }

        public Vehicle? GetByPlate(string plateNumber)
        {
            return _context.Vehicles.FirstOrDefault(v => v.PlateNumber == plateNumber);
        }

    }
}



