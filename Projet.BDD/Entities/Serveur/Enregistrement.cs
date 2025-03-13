using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Serveur
{
    public class Enregistrement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string NumeroCarteBancaire { get; set; }
        
        [Required]
        public double MontantOperation { get; set; }

        [Required]
        public EnumOperation TypeOperation { get; set; }

        [Required]
        public DateTime DateOperation { get; set; }

        [Required]
        public string Devise { get; set; }

        [Required]
        public double tauxConvertion { get; set; }
    }
}
