using CarCheck.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Domain.Core.Contract.Services
{
    public interface IVehicleModelService
    {
        void Add(VehicleModel model);
        VehicleModel? GetById(int id);
        List<VehicleModel> GetAll();
    }


}
