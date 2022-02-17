using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Locatii
{
    public class EditModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public EditModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LocatieDepozite LocatieDepozite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocatieDepozite = await _context.LocatieDepozite.FirstOrDefaultAsync(m => m.ID == id);

            if (LocatieDepozite == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LocatieDepozite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocatieDepoziteExists(LocatieDepozite.ID))
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

        private bool LocatieDepoziteExists(int id)
        {
            return _context.LocatieDepozite.Any(e => e.ID == id);
        }
    }
}
