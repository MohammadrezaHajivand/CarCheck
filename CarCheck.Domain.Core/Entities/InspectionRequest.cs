using CarCheck.Domain.Core.Enums;


namespace CarCheck.Domain.Core.Entities
{
    public class InspectionRequest
    {
        public int Id { get; set; }
        public DateTime RequestedDate { get; set; }
        public string CompanyName { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }

}
