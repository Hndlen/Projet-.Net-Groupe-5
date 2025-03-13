using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class ClientParticulier : Client
    {
        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }

        [Required]
        public EnumSexe Sexe { get; set; }

        [Required]
        public override string Type => "Particulier";
    }
}
