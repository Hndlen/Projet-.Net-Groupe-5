using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Console.InfoJSON
{
    public class CarteBancaireJSON
    {
        [JsonPropertyName("numero")]
        public string Numero { get; set; }
        [JsonPropertyName("compteCarteId")]
        public string CompteCarteId { get; set; }
        
        /*
        [JsonPropertyName("compteBancaire")]
        public CompteBancaire? CompteBancaire { get; set; }*/
    }
}
