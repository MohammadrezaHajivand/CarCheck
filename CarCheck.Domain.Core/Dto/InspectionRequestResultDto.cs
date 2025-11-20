namespace CarCheck.Domain.Core.Dto;

    public class InspectionRequestResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int? RequestId { get; set; }
    }
