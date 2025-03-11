using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Projet.Console.InfoJSON
{
    public class ClientJSON
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nom")]
        public string Nom { get; set; }
        [JsonPropertyName("adresseClientId")]
        public int AdresseClientId { get; set; }
        [JsonPropertyName("adresseClient")]
        public Adresse? AdresseClient { get; set; }
        [JsonPropertyName("mail")]
        public string Mail { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("compteBancaire")]
        public CompteBancaire? CompteBancaire { get; set; }
    }
}
