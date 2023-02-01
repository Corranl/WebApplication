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
    public class IndexModel: PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public IndexModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

        public IList<CmdClient> CmdClient { get;set; }

        public async Task OnGetAsync()
        {
            CmdClient = await _context.CmdClient.ToListAsync();
        }
    }
}
