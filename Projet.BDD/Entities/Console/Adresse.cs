using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class Adresse
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Libelle { get; set; }
        
        [StringLength(100, MinimumLength = 1)]
        public string? Complement { get; set; }
        
        [Required]
        public int CodePostal { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Ville { get; set; }
        

    }
}
