using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Service.Service;

public class VehicleModelService(IVehicleModelRepository _modelRepo) : IVehicleModelService
{

    public void Add(VehicleModel model)
    {
        _modelRepo.Add(model);
    }

    public VehicleModel? GetById(int id)
    {
        return _modelRepo.GetById(id);
    }

    public List<VehicleModel> GetAll()
    {
        return _modelRepo.GetAll();
    }
}
