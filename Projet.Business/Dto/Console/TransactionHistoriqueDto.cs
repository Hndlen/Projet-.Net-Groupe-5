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

        public TransactionHistoriqueDto(int id,string compteCarteId, string numeroCarteBancaire, double montantOperation,string typeOperation, DateTime dateOperation,string devise)
        {
            //this.Id = id;
            this.CompteCarteId = compteCarteId;
            this.NumeroCarteBancaire = numeroCarteBancaire;
            this.MontantOperation = montantOperation;
            this.TypeOperation = typeOperation;
            this.DateOperation = dateOperation;
            this.Devise = devise;
            
        }
    }
}
