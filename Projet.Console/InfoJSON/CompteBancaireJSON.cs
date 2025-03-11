using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Console.InfoJSON
{
    public class CompteBancaireJSON
    {
        [JsonPropertyName("numero")]
        public string Numero { get; set; }
        [JsonPropertyName("dateOuverture")]
        public DateTime DateOuverture { get; set; }
        [JsonPropertyName("solde")]
        public double Solde { get; set; }
        [JsonPropertyName("cartesBancaire")]
        public ICollection<CarteBancaire> CartesBancaire { get; set; }
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
        
        //public string CompteCarteId { get; set; }
        /*
        [JsonPropertyName("compteBancaire")]
        public CompteBancaire? CompteBancaire { get; set; }*/
    }
}
