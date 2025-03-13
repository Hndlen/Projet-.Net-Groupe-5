using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Console.InfoJSON
{
    public class TransactionJSON
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("compteCarteId")]
        public string CompteCarteId { get; set; }
        [JsonPropertyName("numeroCarteBancaire")]
        public string NumeroCarteBancaire { get; set; }
        [JsonPropertyName("montantOperation")]
        public double MontantOperation { get; set; }
        [JsonPropertyName("typeOperation")]
        public string TypeOperation { get; set; }
        [JsonPropertyName("dateOperation")]
        public DateTime DateOperation { get; set; }
        [JsonPropertyName("devise")]
        public string Devise { get; set; }
        
    
    }
}
