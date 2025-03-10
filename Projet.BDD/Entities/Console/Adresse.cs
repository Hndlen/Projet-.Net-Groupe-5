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
        public string Ville { get; set; }
        public int CodePostal { get; set; }

        public Adresse(string libelle, string complement, string ville, int codePostal)
        {
            this.Libelle = libelle;
            this.Complement = complement;
            this.Ville = ville;
            this.CodePostal = codePostal;
        }

    }
}
