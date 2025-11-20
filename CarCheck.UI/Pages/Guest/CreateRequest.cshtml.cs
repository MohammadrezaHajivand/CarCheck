using CarCheck.Application.Services.Interfaces;
using CarCheck.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCheck.UI.Pages.Guest
{
    public class CreateRequestModel : PageModel
    {
        private readonly IVehicleModelAppService _modelService;
        private readonly IInspectionRequestAppService _requestService;

        public CreateRequestModel(IVehicleModelAppService modelService, IInspectionRequestAppService requestService)
        {
            _modelService = modelService;
            _requestService = requestService;
        }

        public List<VehicleModelDto> Models { get; set; }

        [BindProperty]
        public CreateInspectionRequestDto Dto { get; set; }


        public string Message { get; set; }

        public void OnGet()
        {
            Models = _modelService.GetAll();
        }

        public IActionResult OnPost(CreateInspectionRequestDto dto)
        {
            var result = _requestService.CreateRequest(dto);
            Message = result.Message;
            Models = _modelService.GetAll();
            return Page();
        }
    }
}
