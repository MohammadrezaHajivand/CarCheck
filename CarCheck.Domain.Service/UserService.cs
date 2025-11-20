using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Entities;

namespace CarCheck.Domain.Service.Service
{
    public class UserService(IUserRepository userRepo) : IUserService
    {
        public void Add(User user)
        {
            userRepo.Add(user);
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll();
        }

        public User? GetById(int id)
        {
            return userRepo.GetById(id);
        }

        public User? GetByNationalCode(string nationalCode)
        {
            return userRepo.GetByNationalCode(nationalCode);
        }
    }
}
