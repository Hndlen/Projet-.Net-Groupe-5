using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class CompteAdmin
    {
        [Key]
        [StringLength(50, MinimumLength = 5)]
        public string Identifiant { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Mdp { get; set; }
    }
}
