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
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public IndexModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Utilisateur> Utilisateur { get;set; }

        public async Task OnGetAsync()
        {
            Utilisateur = await _context.Utilisateurs.ToListAsync();
        }
    }
}
