namespace CarCheck.Domain.Core.Dto;

public class CreateInspectionRequestDto
{
    public string FullName { get; set; }
    public string NationalCode { get; set; }

    public string PlateNumber { get; set; }
    public int YearOfManufacture { get; set; }
    public int ModelId { get; set; }

    public DateTime RequestedDate { get; set; }
}
