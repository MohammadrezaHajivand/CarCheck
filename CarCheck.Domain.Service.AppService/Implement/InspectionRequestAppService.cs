using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;
using CarCheck.Domain.Core.Enums;

namespace CarCheck.Application.Services.Implement;

public class InspectionRequestAppService(IUserService _userService, IVehicleService _vehicleService, IInspectionRequestService _requestService): IInspectionRequestAppService
{
    public InspectionRequestResultDto CreateRequest(CreateInspectionRequestDto dto)
    {
        var user = _userService.GetByNationalCode(dto.NationalCode);
        if (user == null)
        {
            user = new User
            {
                FullName = dto.FullName,
                NationalCode = dto.NationalCode
            };
            _userService.Add(user);
        }

        var vehicle = _vehicleService.GetByPlate(dto.PlateNumber);
        if (vehicle == null)
        {
            vehicle = new Vehicle
            {
                PlateNumber = dto.PlateNumber,
                YearOfManufacture = dto.YearOfManufacture,
                ModelId = dto.ModelId,
                OwnerId = user.Id
            };
            _vehicleService.Add(vehicle);
        }

        var count = _requestService.CountByDate(dto.RequestedDate);
        if (count >= 50)
        {
            return new InspectionRequestResultDto
            {
                IsSuccess = false,
                Message = "ظرفیت روز انتخاب‌شده تکمیل شده است.",
                RequestId = null
            };
        }

        var request = new InspectionRequest
        {
            VehicleId = vehicle.Id,
            UserId = user.Id,
            RequestedDate = dto.RequestedDate.Date,
            CompanyName = "شرکت معاینه فنی مرکزی",
            Status = RequestStatus.Pending,
            CreatedAt = DateTime.Now
        };

        _requestService.Add(request);

        return new InspectionRequestResultDto
        {
            IsSuccess = true,
            Message = "درخواست با موفقیت ثبت شد.",
            RequestId = request.Id
        };
    }
}