using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Core.Contract.Services;

public interface IInspectionRequestService
{
    void Add(InspectionRequest request);
    int CountByDate(DateTime date);
    List<InspectionRequest> GetByUserId(int userId);
    InspectionRequest? GetById(int id);
    List<InspectionRequest> GetAll();
}
