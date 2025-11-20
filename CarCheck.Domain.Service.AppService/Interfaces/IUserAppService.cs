using CarCheck.Domain.Core.Dto;
using CarCheck.Domain.Core.Entities;


namespace CarCheck.Application.Services.Interfaces;

public interface IUserAppService
{
    User AddUser(CreateUserDto dto);
    User? GetByNationalCode(string nationalCode);
}


