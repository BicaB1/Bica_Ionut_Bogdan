using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext _context;

        public IndexModel(Bica_Ionut_Bogdan.Models.Bica_Ionut_BogdanContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }

        public async Task OnGetAsync()
        {
            Produs = await _context.Produs
                .Include(p => p.CategorieAlergii)
                .Include(p => p.LocatieDepozite).ToListAsync();
        }
    }
}
