using CarCheck.Domain.Core.Contract.Repositories;
using CarCheck.Domain.Core.Entities;
using CarCheck.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;


namespace CarCheck.Infrastructure.EFCore.Repositories
{
    public class InspectionRequestRepository(CarCheckDbContext _context) : IInspectionRequestRepository
    {
        public void Add(InspectionRequest request)
        {
            _context.InspectionRequests.Add(request);
            _context.SaveChanges();
        }

        public int CountByDate(DateTime date)
        {
            return _context.InspectionRequests.Count(r => r.RequestedDate.Date == date.Date);
        }

        public List<InspectionRequest> GetByUserId(int userId)
        {
            return _context.InspectionRequests
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }

        public InspectionRequest? GetById(int id)
        {
            return _context.InspectionRequests.FirstOrDefault(r => r.Id == id);
        }

        public List<InspectionRequest> GetAll()
        {
            return _context.InspectionRequests
                .Include(r => r.User)
                .Include(r => r.Vehicle)
                .ToList();
        }
        public InspectionRequest? GetLastByPlate(string plateNumber)
        {
            return _context.InspectionRequests
                .Include(r => r.Vehicle)
                .Where(r => r.Vehicle.PlateNumber == plateNumber)
                .OrderByDescending(r => r.RequestedDate)
                .FirstOrDefault();
        }
    }
}
