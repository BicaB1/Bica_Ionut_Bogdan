using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bica_Ionut_Bogdan.Models;

namespace Bica_Ionut_Bogdan.Models
{
    public class Bica_Ionut_BogdanContext : DbContext
    {
        public Bica_Ionut_BogdanContext (DbContextOptions<Bica_Ionut_BogdanContext> options)
            : base(options)
        {
        }

        public DbSet<Bica_Ionut_Bogdan.Models.Produs> Produs { get; set; }

        public DbSet<Bica_Ionut_Bogdan.Models.LocatieDepozite> LocatieDepozite { get; set; }

        public DbSet<Bica_Ionut_Bogdan.Models.CategorieAlergii> CategorieAlergii { get; set; }
    }
}
