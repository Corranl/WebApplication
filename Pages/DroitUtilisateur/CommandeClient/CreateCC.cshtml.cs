using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Data;
using WebApplication.Model;

namespace WebApplication.Pages.DroitUtilisateur.CommandeClient
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
        public CmdClient CmdClient { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CmdClient.Add(CmdClient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
