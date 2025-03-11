using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Business.Dto.Console
{
    public class ClientProfessionnelDto : ClientDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "siret requis")]
        [JsonPropertyName("siret")]

        public string Siret { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "status juridique requis")]
        public EnumStatutJuridique StatutJuridique { get; set; }

        public int AdresseSiegeId { get; set; }
        public AdresseDto AdresseSiege { get; set; }

        public override string Type => "Professionnel";

    }
}
