using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet.BDD.Entities.Console;

namespace Projet.Business.Dto.Console
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nom { get; set; }

        public int AdresseClientId { get; set; }
        public Adresse AdresseClient { get; set; }
        
        public string Mail { get; set; }

        public virtual string Type { get; }

        public CompteBancaireDto CompteBancaire { get; set; }
    }
}
