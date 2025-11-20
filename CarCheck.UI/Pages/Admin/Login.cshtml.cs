using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCheck.UI.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string Username { get; set; }
        [BindProperty] public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "1234")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToPage("/Admin/Requests");
            }

            ErrorMessage = "نام کاربری یا رمز عبور اشتباه است.";
            return Page();
        }
    }

}
