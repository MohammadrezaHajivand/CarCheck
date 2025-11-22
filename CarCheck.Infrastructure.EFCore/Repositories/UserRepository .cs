using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Entities;
using CarCheck.Infrastructure.EFCore.Persistence;


namespace CarCheck.Infrastructure.EFCore.Repositories
{
    public class UserRepository(CarCheckDbContext _context) : IUserRepository
    {
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByNationalCode(string nationalCode)
        {
            return _context.Users.FirstOrDefault(u => u.NationalCode == nationalCode);
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public User? GetByNationalCodeAndPassword(string nationalCode, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.NationalCode == nationalCode && u.Password == password);
        }


    }
}



