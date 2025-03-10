using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class CompteBancaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Numero { get; set; }

        public DateTime DateOuverture { get; set; }
        public double Solde { get; set; }
        public ICollection<CarteBancaire> CartesBancaire { get; set; }
        public int ClientId { get; set; }
        public Client Titulaire { get; set; }

    }
}
