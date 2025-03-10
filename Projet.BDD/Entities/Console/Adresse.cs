using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class Adresse
    {
        public string Libelle { get; set; }
        public string Complement { get; set; }
        
        public int CodePostal { get; set; }
        public string Ville { get; set; }


    }
}
