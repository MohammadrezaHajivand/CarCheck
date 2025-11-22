using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Core.Contract.Services
{
    public interface IUserService
    {
        void Add(User user);
        User? GetById(int id);
        List<User> GetAll();
        User? GetByNationalCode(string nationalCode);
        User? Login(string nationalCode, string password);
    }
}
