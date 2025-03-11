using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet.Serveur.Generation
{
    public enum EnumOperation
    {
        Retrait,
        Depot,
        Facture
    }

    public class Operation
    {
        // Propriétés publiques avec les noms respectant la convention PascalCase
        [JsonPropertyName("numeroCarteBancaire")]
        public string NumeroCarteBancaire { get; set; }

        public double Montant { get; set; }

        public EnumOperation Type { get; set; }

        public DateTime Date { get; set; }

        public string Devise { get; set; }

        public double TauxConversion { get; set; }

        // Générateur de nombres aléatoires
        private static Random random = new Random();

        // Constructeur
        public Operation()
        {
            SetNumeroCarteBancaire();
            SetType();
            SetMontant();
            Date = DateTime.Now;  // Date d'aujourd'hui
            SetDevise();
        }

        // Méthode pour générer un numéro de carte bancaire aléatoire
        private void SetNumeroCarteBancaire()
        {
            string numeroCB = "4000 0000 0000 1091";

            //for (int i = 0; i < 4; i++)
            //{
            //    numeroCB += random.Next(0, 10).ToString();
            //}

            this.NumeroCarteBancaire = numeroCB;
        }

        // Méthode pour générer un montant aléatoire
        private void SetMontant()
        {
            double randomMontant = random.NextDouble() * 10000;

            if (Type == EnumOperation.Depot)
            {
                this.Montant = Math.Round(randomMontant, 2);
            }
            else
            {
                this.Montant = Math.Round(-randomMontant, 2);
            }
        }

        // Méthode pour générer une devise aléatoire
        private void SetDevise()
        {
            string[] devises = { "EUR", "USD", "YUAN", "YEN" };
            int index = random.Next(devises.Length);
            this.Devise = devises[index];
        }

        // Méthode pour définir le type d'opération aléatoire
        private void SetType()
        {
            Array types = Enum.GetValues(typeof(EnumOperation));
            this.Type = (EnumOperation)types.GetValue(random.Next(types.Length));
        }

        // Méthode pour afficher les informations de la transaction
        public void AfficherTransaction()
        {
            Console.WriteLine($"Numéro CB : {NumeroCarteBancaire}, Type : {Type}, Montant : {Montant} {Devise}, Date : {Date}");
        }
    }

}
