using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Projet.BDD.Entities.Console
{
    public class TransactionsHistorique
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompteCarteId { get; set; }
        [Required]
        public string NumeroCarteBancaire { get; set; }
        [Required]
        public double MontantOperation { get; set; }
        [Required]
        public string TypeOperation { get; set; }
        [Required]
        public DateTime DateOperation { get; set; }
        [Required]
        public string Devise { get; set; }
    }
}
    

