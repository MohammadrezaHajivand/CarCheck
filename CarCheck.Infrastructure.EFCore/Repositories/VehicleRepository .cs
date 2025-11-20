using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Entities;
using CarCheck.Infrastructure.EFCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Infrastructure.EFCore.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CarCheckDbContext _context;

        public VehicleRepository(CarCheckDbContext context)
        {
            _context = context;
        }

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
