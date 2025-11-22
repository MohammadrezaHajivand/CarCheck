namespace CarCheck.Domain.Core.Dto;

public class CreateInspectionRequestDto
{
    //enteghale data az view be app service baraye validation
    public string FullName { get; set; }
    public string NationalCode { get; set; }
    public string PlateNumber { get; set; }
    public DateTime YearOfManufacture { get; set; }
    public int ModelId { get; set; }
    public DateTime RequestedDate { get; set; }
}
