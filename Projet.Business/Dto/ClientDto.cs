using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet.BDD.Entities.Console
{
    public class ClientDto
    {
        public int Id { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "le nom du client est requis")]
        public string Nom { get; set; }

        public int AdresseClientId { get; set; }
        public Adresse AdresseClient { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "le mail du client est requis")]
        public string Mail { get; set; }

        public virtual string Type { get; }

        public CompteBancaireDto CompteBancaire { get; set; }
    }
}
