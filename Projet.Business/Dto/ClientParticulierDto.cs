using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class ClientParticulierDto : ClientDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "date de naissance requise")]
        public DateTime DateNaissance { get; set; }

        public string Prenom { get; set; }

        public EnumSexe Sexe { get; set; }

        public override string Type => "Particulier";
    }
}
