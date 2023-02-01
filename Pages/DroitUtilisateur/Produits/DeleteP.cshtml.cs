using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.DroitUtilisateur.Produits
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public DeleteModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produit Produit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produit = await _context.Produits.FirstOrDefaultAsync(m => m.Id == id);

            if (Produit == null)
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

            Produit = await _context.Produits.FindAsync(id);

            if (Produit != null)
            {
                _context.Produits.Remove(Produit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexP");
        }
    }
}
