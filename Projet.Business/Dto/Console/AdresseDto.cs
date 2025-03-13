using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Dto.Console
{
    public class AdresseDto
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "le libelle est requis")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Le nom ne peut dépasser 100 caracteres")]
        public string Libelle { get; set; }

        public string Complement { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "le code postal est requis")]
        public int CodePostal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ville est requise")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Le nom ne peut dépasser 30 caracteres")]
        public string Ville { get; set; }


    }
}
