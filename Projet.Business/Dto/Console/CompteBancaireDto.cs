using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Dto.Console
{
    public class CompteBancaireDto
    {
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "date ouverture requise")]
        public DateTime DateOuverture { get; set; }
        public double Solde { get; set; }
        public ICollection<CarteBancaireDto> CartesBancaire { get; set; }
        public int ClientId { get; set; }
        public ClientDto Titulaire { get; set; }

    }
}
