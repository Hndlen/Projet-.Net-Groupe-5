using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet.BDD.Entities.Console
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }

        public Adresse AdresseClient { get; set; }
        public string Mail { get; set; }
    }
}
