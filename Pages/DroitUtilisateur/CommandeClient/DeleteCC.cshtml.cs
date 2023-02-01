using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Model;

namespace WebApplication.Pages.DroitUtilisateur.CommandeClient
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public DeleteModel(WebApplication.Data.DataContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CmdClient = await _context.CmdClient.FindAsync(id);

            if (CmdClient != null)
            {
                _context.CmdClient.Remove(CmdClient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
