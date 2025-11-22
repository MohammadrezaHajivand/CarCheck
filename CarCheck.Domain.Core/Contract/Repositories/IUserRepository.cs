using CarCheck.Domain.Core.Entities;


namespace CarCheck.Domain.Core.Contract.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(int id);
        List<User> GetAll();
        User? GetByNationalCode(string nationalCode);
        User? GetByNationalCodeAndPassword(string nationalCode, string password);
        User? GetByUsername(string username);
    }


}
