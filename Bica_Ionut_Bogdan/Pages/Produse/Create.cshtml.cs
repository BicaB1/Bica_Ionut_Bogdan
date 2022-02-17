using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Produse
{
    public class CreateModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public CreateModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategorieAlergiiID"] = new SelectList(_context.Set<CategorieAlergii>(), "ID", "catAlergii");
        ViewData["LocatieDepoziteID"] = new SelectList(_context.Set<LocatieDepozite>(), "ID", "locatieDepozit");
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}