using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public EditModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(p => p.CategorieAlergii)
                .Include(p => p.LocatieDepozite).FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }
           ViewData["CategorieAlergiiID"] = new SelectList(_context.Set<CategorieAlergii>(), "ID", "catAlergii");
           ViewData["LocatieDepoziteID"] = new SelectList(_context.Set<LocatieDepozite>(), "ID", "locatieDepozit");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.ID))
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

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
