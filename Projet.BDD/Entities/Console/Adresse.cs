using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Console
{
    public class Adresse
    {



        [Key]
        public string Libelle { get; set; }
        public string Complement { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        

        /*public Adresse(string libelle, string complement,  int codePostal, string ville)
        {
            this.Libelle = libelle;
            this.Complement = complement;
            this.CodePostal = codePostal;
            this.Ville = ville;
            
        }*/

    }
}
