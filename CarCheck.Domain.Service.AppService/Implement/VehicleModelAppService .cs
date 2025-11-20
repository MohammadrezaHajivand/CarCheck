using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Dto;


namespace CarCheck.Application.Services.Implement;

public class VehicleModelAppService : IVehicleModelAppService
{
    private readonly IVehicleModelRepository _repository;

    public VehicleModelAppService(IVehicleModelRepository repository)
    {
        _repository = repository;
    }

    public List<VehicleModelDto> GetAll()
    {
        var models = _repository.GetAll();
        return models.Select(m => new VehicleModelDto
        {
            Id = m.Id,
            Name = m.Name
        }).ToList();
    }
    
}


