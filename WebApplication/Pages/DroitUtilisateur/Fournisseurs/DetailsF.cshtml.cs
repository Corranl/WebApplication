﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Data.DataContext _context;

        public DetailsModel(WebApplication.Data.DataContext context)
        {
            _context = context;
        }

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
    }
}
