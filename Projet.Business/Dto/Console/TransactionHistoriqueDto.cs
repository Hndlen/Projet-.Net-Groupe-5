using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Dto.Console
{
    public class TransactionHistoriqueDto
    {
        public int Id { get; set; }
        [Required]
        public string CompteCarteId { get; set; }
        [Required]
        public string NumeroCarteBancaire { get; set; }
        [Required]
        public double MontantOperation { get; set; }
        [Required]
        public string TypeOperation { get; set; }
        [Required]
        public DateTime DateOperation { get; set; }
        public string Devise { get; set; }
    }
}
