using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Dto
{
    public class AdresseDto
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "le libelle est requis")]
        //[StringLength(30, MinimumLength = 1, ErrorMessage = "Le nom ne peut dépasser 30 caracteres")]
        public string Libelle { get; set; }
        public string Complement { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "le code postal est requis")]
        public int CodePostal { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ville est requise")]
        public string Ville { get; set; }



        /*public Adresse(string libelle, string complement,  int codePostal, string ville)
        {
            this.Libelle = libelle;
            this.Complement = complement;
            this.CodePostal = codePostal;
            this.Ville = ville;
            
        }*/

    }
}
