using CarCheck.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCheck.UI.Pages.Admin;

public class LoginModel : PageModel
{
    private readonly IUserAppService _userAppService;

    public LoginModel(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [BindProperty]
    public string NationalCode { get; set; }

    public string Message { get; set; }


    public IActionResult OnPost()
    {
        var user = _userAppService.GetByNationalCode(NationalCode);
        if (user == null)
        {
            Message = "کاربر یافت نشد";
            return Page();
        }

        return RedirectToPage("CreateRequest", new { userId = user.Id });
    }

    public IActionResult OnPostGuest()
    {
        return RedirectToPage("/Admin/Requests", new { userId = 0 });
    }
}
