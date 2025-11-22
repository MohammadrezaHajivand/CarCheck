using CarCheck.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCheck.UI.Pages.Admin;

public class LoginModel(IAuthAppService _authAppService) : PageModel
{
    [BindProperty]
    public string NationalCode { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; }

    public IActionResult OnPost()
    {
        var result = _authAppService.Login(NationalCode, Password);

        if (!result.IsSuccess)
        {
            Message = result.Message;
            return Page();
        }

        if (result.IsAdmin)
        {
            return RedirectToPage("/Admin/Requests");
        }

        return RedirectToPage("/User/CreateRequest", new { userId = result.UserId });
    }

    public IActionResult OnPostGuest()
    {
        var result = _authAppService.Login(null, null, guest: true);
        return RedirectToPage("/Guest/CreateRequest", new { userId = 0 });
    }
}
