using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Projet.BDD.Entities.Console
{
    public abstract class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }

        [Required]
        public int AdresseClientId { get; set; }
        public Adresse AdresseClient { get; set; }
        
        [Required]
        public string Mail { get; set; }
        
        [Required]
        public abstract string Type { get; }

        public CompteBancaire CompteBancaire { get; set; }
    }
}
