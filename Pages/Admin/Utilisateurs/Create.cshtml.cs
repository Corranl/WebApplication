using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.Admin.Utilisateurs

{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public CreateModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Utilisateur Utilisateur { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Utilisateurs.Add(Utilisateur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
