using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class CarteBancaire
    {
        [Key]
        public string Numero { get; set; }
        public string? CompteCarteId { get; set; }
        [JsonIgnore]
        public CompteBancaire? CompteCarte { get; set; }
    }
}
