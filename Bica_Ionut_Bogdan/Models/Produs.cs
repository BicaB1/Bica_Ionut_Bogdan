using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bica_Ionut_Bogdan.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Display(Name = "Produs Denumire")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string produsNume { get; set; }

        [Display(Name = "Produs Descriere")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string produsDescriere { get; set; }

        [Display(Name = "Produs Seal of Approval")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string produsSeal { get; set; }

        [Display(Name = "Data Expirare")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        [DataType(DataType.Date)]
        public DateTime produsExp { get; set; }

        [Display(Name = "Categorie Alergii")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int CategorieAlergiiID { get; set; }
        public CategorieAlergii CategorieAlergii { get; set; }

        [Display(Name = "Depozit")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int LocatieDepoziteID { get; set; }
        public LocatieDepozite LocatieDepozite { get; set; }


    }
}
