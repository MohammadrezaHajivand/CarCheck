using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Core.Contract.Repositories
{
    public interface IVehicleModelRepository
    {
        void Add(VehicleModel model);
        VehicleModel? GetById(int id);
        List<VehicleModel> GetAll();
    }


}
