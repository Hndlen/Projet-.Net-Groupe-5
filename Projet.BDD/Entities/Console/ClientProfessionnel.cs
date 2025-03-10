using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class ClientProfessionnel : Client
    {
        public string Siret { get; set; }

        public EnumStatutJuridique StatutJuridique { get; set; }

        public Adresse AdresseSiege { get; set; }
    }
}
