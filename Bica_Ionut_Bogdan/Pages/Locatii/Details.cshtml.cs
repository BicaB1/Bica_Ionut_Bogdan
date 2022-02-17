using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Locatii
{
    public class DetailsModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public DetailsModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

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
    }
}
