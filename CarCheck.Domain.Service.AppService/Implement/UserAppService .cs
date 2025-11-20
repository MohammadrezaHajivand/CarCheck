using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Application.Services.Implement;

public class UserAppService(IUserService _userService) : IUserAppService
{
    public User AddUser(CreateUserDto dto)
    {
        var existingUser = _userService.GetByNationalCode(dto.NationalCode);
        if (existingUser != null)
            return existingUser;

        var user = new User
        {
            FullName = dto.FullName,
            NationalCode = dto.NationalCode
        };

        _userService.Add(user);
        return user;
    }

    public User? GetByNationalCode(string nationalCode)
    {
        return _userService.GetByNationalCode(nationalCode);
    }
}


