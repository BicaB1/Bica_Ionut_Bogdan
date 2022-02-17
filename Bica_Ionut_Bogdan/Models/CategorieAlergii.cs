using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bica_Ionut_Bogdan.Models
{
    public class CategorieAlergii
    {
        public int ID { get; set; }

        [Display(Name = "Categorie Alergii")]
        [Required(ErrorMessage = "Va rog sa completati campul.."), MinLength(3, ErrorMessage = "Necesar minim trei caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string catAlergii { get; set; }
    }
}
