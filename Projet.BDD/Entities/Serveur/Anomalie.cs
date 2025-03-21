﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Entities.Serveur
{
    public class Anomalie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public double? MontantOperation { get; set; }
        public EnumOperation? TypeOperation { get; set; }
        public DateTime? DateOperation { get; set; }
        public string? Devise { get; set; }
        public double? tauxConvertion { get; set; }
        [Required]
        public string Erreur { get; set; }
    }
}
