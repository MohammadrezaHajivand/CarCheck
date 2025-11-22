using CarCheck.Domain.Core.Dto;

namespace CarCheck.Application.Services.Interfaces
{
    public interface IAuthAppService
    {
        AuthResultDto Login(string? nationalCode, string? password, bool guest = false);
    }


}
