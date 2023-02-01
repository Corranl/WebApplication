using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.DroitUtilisateur.Fournisseurs
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public EditModel(WebApplication.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fournisseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(Fournisseur.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexF");
        }

        private bool FournisseurExists(int id)
        {
            return _context.Fournisseurs.Any(e => e.Id == id);
        }
    }
}
