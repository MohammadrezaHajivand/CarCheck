using CarCheck.Domain.Core.Dto;

namespace CarCheck.Application.Services.Interfaces;

public interface IInspectionRequestAppService
{
    InspectionRequestResultDto CreateRequest(CreateInspectionRequestDto dto);
}
