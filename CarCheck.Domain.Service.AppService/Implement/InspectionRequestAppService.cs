using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;
using CarCheck.Domain.Core.Enums;

namespace CarCheck.Application.Services.Implement;

public class InspectionRequestAppService(
    IUserService _userService,
    IVehicleService _vehicleService,
    IInspectionRequestService _requestService,
    IVehicleModelService _modelService) : IInspectionRequestAppService
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
        var lastRequest = _requestService.GetLastByPlate(dto.PlateNumber);

        if (lastRequest != null && lastRequest.RequestedDate.Date > DateTime.Today.AddYears(-1))
        {
            return new InspectionRequestResultDto
            {
                IsSuccess = false,
                Message = "این خودرو در سال جاری قبلاً درخواست معاینه فنی ثبت کرده است.",
                RequestId = null
            };
        }

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

        var model = _modelService.GetById(dto.ModelId);
        var manufacturer = model.Manufacturer?.Trim();
        var day = dto.RequestedDate.Day;
        bool isEvenDay = day % 2 == 0;

        if (manufacturer == "ایران خودرو" && !isEvenDay)
        {
            return new InspectionRequestResultDto
            {
                IsSuccess = false,
                Message = "برای خودروهای ایران خودرو فقط در روزهای زوج می‌توان درخواست ثبت کرد.",
                RequestId = null
            };
        }

        if (manufacturer == "سایپا" && isEvenDay)
        {
            return new InspectionRequestResultDto
            {
                IsSuccess = false,
                Message = "برای خودروهای سایپا فقط در روزهای فرد می‌توان درخواست ثبت کرد.",
                RequestId = null
            };
        }

        var count = _requestService.CountByDate(dto.RequestedDate);
        int maxRequests = isEvenDay ? 15 : 10;

        if (count >= maxRequests)
        {
            return new InspectionRequestResultDto
            {
                IsSuccess = false,
                Message = "ظرفیت روز انتخاب‌شده تکمیل شده است.",
                RequestId = null
            };
        }

        int yearsInUse = dto.RequestedDate.Year - dto.YearOfManufacture.Year;

        var request = new InspectionRequest
        {
            VehicleId = vehicle.Id,
            UserId = user.Id,
            RequestedDate = dto.RequestedDate.Date,
            CompanyName = "شرکت معاینه فنی مرکزی",
            Status = yearsInUse <= 5 ? RequestStatus.Pending : RequestStatus.Rejected,
            CreatedAt = DateTime.Now
        };

        _requestService.Add(request);

        return new InspectionRequestResultDto
        {
            IsSuccess = yearsInUse <= 5,
            Message = yearsInUse <= 5
                ? "درخواست با موفقیت ثبت شد."
                : "درخواست موفقیت‌آمیز نبود، از سال ساخت خودرو بیشتر از ۵ سال گذشته است.",
            RequestId = request.Id
        };
    }
}