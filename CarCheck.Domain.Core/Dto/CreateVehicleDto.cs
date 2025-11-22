

namespace CarCheck.Domain.Core.Dto
{
    public class CreateVehicleDto
    {
        public string PlateNumber { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public int ModelId { get; set; }
        public int OwnerId { get; set; }
    }


}
