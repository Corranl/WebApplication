using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
             async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
            {
                if (username == "admin")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                   ClaimsPrincipal(claimsIdentity));
                    return Redirect(ReturnUrl == null ? "/Admin/Utilisateurs" : ReturnUrl);
                }
                return Page();
            }
        }
    }
}
