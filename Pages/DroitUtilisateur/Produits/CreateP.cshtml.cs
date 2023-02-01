using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication;
using WebApplication.Data;

namespace WebApplication.Pages.DroitUtilisateur.Produits
{
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
        public Produit Produit { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IndexP");
        }
    }
}
