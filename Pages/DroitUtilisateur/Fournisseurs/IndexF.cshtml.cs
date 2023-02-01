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
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public IndexModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Fournisseur> Fournisseur { get;set; }

        public async Task OnGetAsync()
        {
            Fournisseur = await _context.Fournisseurs.ToListAsync();
        }
    }
}
