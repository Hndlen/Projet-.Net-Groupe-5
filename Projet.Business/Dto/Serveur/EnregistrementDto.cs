using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Dto
{
    public class EnregistrementDto
    {
        public int Id { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public double MontantOperation { get; set; }
        public EnumOperation TypeOperation { get; set; }
        public DateTime DateOperation { get; set; }
        public string Devise { get; set; }


        /*public Adresse(string libelle, string complement,  int codePostal, string ville)
        {
            this.Libelle = libelle;
            this.Complement = complement;
            this.CodePostal = codePostal;
            this.Ville = ville;
            
        }*/

    }
}
