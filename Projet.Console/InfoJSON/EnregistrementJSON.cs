using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Console.InfoJSON
{
    public class EnregistrementJSON
    {
        public int Id { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal MontantOperation { get; set; }
        public string TypeOperation { get; set; }
        public string DateOperation { get; set; }
        public string Devise { get; set; }
    }
}
