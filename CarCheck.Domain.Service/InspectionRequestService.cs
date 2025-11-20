using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Service.Service
{
    public class InspectionRequestService(IInspectionRequestRepository inspectionRepo) : IInspectionRequestService
    {
        public void Add(InspectionRequest request)
        {
            inspectionRepo.Add(request);
        }

        public int CountByDate(DateTime date)
        {
            return inspectionRepo.CountByDate(date);
        }

        public List<InspectionRequest> GetAll()
        {
            return inspectionRepo.GetAll();
        }

        public InspectionRequest? GetById(int id)
        {
            return inspectionRepo.GetById(id);
        }

        public List<InspectionRequest> GetByUserId(int userId)
        {
            return inspectionRepo.GetByUserId(userId);
        }
    }
}
