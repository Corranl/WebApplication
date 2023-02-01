using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool DisplayInvalidAccountMessage = false;

         IConfiguration Configuration;
        public IndexModel(IConfiguration Configuration) 
        {
            this.Configuration = Configuration;
        }
        public IActionResult OnGet()
        {  
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/IndexAdmin");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            var authSection = Configuration.GetSection("Auth");
            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];

            var authSectionUtilisateur = Configuration.GetSection("AuthUtilisateur");
            string utilisateurLogin = authSectionUtilisateur["UtilisateurLogin"];
            string utilisateurPassword = authSectionUtilisateur["UtilisateurPassword"];
            // var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(m => m.Id == id);

            if ((username == adminLogin) && (password == adminPassword))
            {
                DisplayInvalidAccountMessage = false;
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "admin")
                    };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
               ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Adminhome" : ReturnUrl);
                
            } 
            else if (username == utilisateurLogin && password == utilisateurPassword)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "user")

                    };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
               ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/DroitUtilisateur/Produits" : ReturnUrl);
            }else
            {
                DisplayInvalidAccountMessage = true;
                return Page();
            }
           
        }
        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/IndexAdmin");
        }
        
    }
}
