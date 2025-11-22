using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;


namespace CarCheck.Application.Services.Implement
{
    public class AuthAppService(IUserService _userService) : IAuthAppService
    {


        public AuthResultDto Login(string? nationalCode, string? password, bool guest = false)
        {
            if (guest)
            {
                return new AuthResultDto
                {
                    IsSuccess = true,
                    IsAdmin = false,
                    UserId = null,
                    Message = "ورود به عنوان مهمان موفقیت‌آمیز بود."
                };
            }

            var user = _userService.Login(nationalCode, password);

            if (user == null)
            {
                return new AuthResultDto
                {
                    IsSuccess = false,
                    Message = "کد ملی یا رمز عبور اشتباه است."
                };
            }

            return new AuthResultDto
            {
                IsSuccess = true,
                IsAdmin = user.IsAdmin,
                UserId = user.Id,
                Message = user.IsAdmin ? "ورود به عنوان ادمین موفقیت‌آمیز بود." : "ورود کاربر عادی موفقیت‌آمیز بود."
            };
        }
    }
}
