using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.DroitUtilisateur.Fournisseurs
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public DeleteModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fournisseur Fournisseur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fournisseur = await _context.Fournisseurs.FirstOrDefaultAsync(m => m.Id == id);

            if (Fournisseur == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fournisseur = await _context.Fournisseurs.FindAsync(id);

            if (Fournisseur != null)
            {
                _context.Fournisseurs.Remove(Fournisseur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexF");
        }
    }
}
