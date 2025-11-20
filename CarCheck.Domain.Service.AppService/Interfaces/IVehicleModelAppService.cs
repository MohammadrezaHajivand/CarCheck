using CarCheck.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCheck.Application.Services.Interfaces
{
    public interface IVehicleModelAppService
    {
        List<VehicleModelDto> GetAll();
    }

}
