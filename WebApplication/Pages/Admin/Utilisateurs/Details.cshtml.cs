using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.Admin.Utilisateurs
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public DetailsModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        public Utilisateur Utilisateur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(m => m.Id == id);

            if (Utilisateur == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
