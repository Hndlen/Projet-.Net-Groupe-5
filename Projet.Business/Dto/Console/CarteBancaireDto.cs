using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Business.Dto.Console
{
    public class CarteBancaireDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "le numéro de la carte est requis")]
        public string Numero { get; set; }
        public string? CompteCarteId { get; set; }
        [JsonIgnore]
        public CompteBancaireDto CompteCarte { get; set; }
    }
}
