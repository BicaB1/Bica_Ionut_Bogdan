using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Categorii
{
    public class DeleteModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public DeleteModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategorieAlergii CategorieAlergii { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategorieAlergii = await _context.CategorieAlergii.FirstOrDefaultAsync(m => m.ID == id);

            if (CategorieAlergii == null)
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

            CategorieAlergii = await _context.CategorieAlergii.FindAsync(id);

            if (CategorieAlergii != null)
            {
                _context.CategorieAlergii.Remove(CategorieAlergii);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
