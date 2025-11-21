using CarCheck.Domain.Core.Contract.Services;
using CarCheck.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCheck.UI.Pages.Admin
{
    public class RequestsModel(IInspectionRequestService _queryService) : PageModel
    {
        public List<InspectionRequestViewDto> Requests { get; set; }

        public IActionResult OnGet()
        {
            
            var entities = _queryService.GetAll();
            Requests = entities.Select(r => new InspectionRequestViewDto
            {
                RequestId = r.Id,
                FullName = r.User?.FullName ?? "‰«„‘Œ’",
                NationalCode = r.User?.NationalCode ?? "‰«„‘Œ’",
                PlateNumber = r.Vehicle?.PlateNumber ?? "‰«„‘Œ’",
                RequestedDate = r.RequestedDate,
                Status = r.Status.ToString()
            }).ToList();

            return Page();
        }
    }
}
