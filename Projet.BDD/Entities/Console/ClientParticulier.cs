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
        public DateTime DateNaissance { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Prenom { get; set; }

        public EnumSexe Sexe { get; set; }
    }
}
