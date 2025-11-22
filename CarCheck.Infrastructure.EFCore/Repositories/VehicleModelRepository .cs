using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Entities;
using CarCheck.Infrastructure.EFCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Infrastructure.EFCore.Repositories;

public class VehicleModelRepository(CarCheckDbContext _context) : IVehicleModelRepository
{

    public void Add(VehicleModel model)
    {
        _context.VehicleModels.Add(model);
        _context.SaveChanges();
    }

    public VehicleModel? GetById(int id)
    {
        return _context.VehicleModels.FirstOrDefault(m => m.Id == id);
    }

    public List<VehicleModel> GetAll()
    {
        return _context.VehicleModels.ToList();
    }
}
