using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class ClientProfessionnel : Client
    {
        [Required]
        public string Siret { get; set; }
        [Required]
        public EnumStatutJuridique StatutJuridique { get; set; }

        public int AdresseSiegeId { get; set; }
        public Adresse AdresseSiege { get; set; }

        public override string Type => "Professionnel";

    }
}
