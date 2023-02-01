using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Model;

namespace WebApplication.Pages.DroitUtilisateur.CommandeClient
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public EditModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CmdClient CmdClient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CmdClient = await _context.CmdClient.FirstOrDefaultAsync(m => m.Id == id);

            if (CmdClient == null)
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

            _context.Attach(CmdClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CmdClientExists(CmdClient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CmdClientExists(int id)
        {
            return _context.CmdClient.Any(e => e.Id == id);
        }
    }
}
