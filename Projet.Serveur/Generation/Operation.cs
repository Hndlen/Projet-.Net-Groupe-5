using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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
            SetTauxConvertion();
        }

        // Méthode pour générer un numéro de carte bancaire aléatoire
        private void SetNumeroCarteBancaire()
        {
            //string numeroCB = "4000 0000 0000 1091";
            String[] numsCB = {
                "4974 0185 0223 4053",
                "4974 0185 0223 4120",
                "4974 0185 0223 4061",
                "4974 0185 0223 4070",
                "4974 0185 0223 4139",
                "4974 0185 0223 4147",
                "4974 0185 0223 4088",
                "4974 0185 0223 4096",
                "4974 0185 0223 4155",
                "4974 0185 0223 4163",
                "4974 0185 0223 4104",
                "4974 0185 0223 4171",
                "4974 0185 0223 4180",
                "4974 0185 0223 4112",
                "4974 0185 0223 4189",
                "4974 0185 0223 4197",
                "4974 0185 0223 4555",  // Mauvais dernier chiffre
                "4974 0185 0223 9144",  // Mauvais dernier chiffre
                "4974 0185 0223 2370",  // Mauvais dernier chiffre
                "4974 0185 0223 6249",  // Mauvais dernier chiffre
                "4974 0185 0223 0895"   // Mauvais dernier chiffre
            };


            //for (int i = 0; i < 4; i++)
            //{
            //    numeroCB += random.Next(0, 10).ToString();
            //}
            int index = random.Next(numsCB.Length);
            this.NumeroCarteBancaire = numsCB[index];
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
            string[] devises = { "EUR", "USD", "CAD", "JPY", "CNY" };
            int index = random.Next(devises.Length);
            this.Devise = devises[index];
        }

        // Méthode pour définir le type d'opération aléatoire
        private void SetType()
        {
            Array types = Enum.GetValues(typeof(EnumOperation));
            this.Type = (EnumOperation)types.GetValue(random.Next(types.Length));
        }

        public  void SetTauxConvertion()
        {
            string url = "https://api.exchangerate-api.com/v4/latest/EUR";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonInfo = response.Content.ReadAsStringAsync().Result;

                    var jsonDoc = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonInfo);

                    if (jsonDoc != null && jsonDoc.ContainsKey("rates"))
                    {
                        var rates = JsonSerializer.Deserialize<Dictionary<string, double>>(jsonDoc["rates"].GetRawText());

                        if (rates != null && rates.ContainsKey(Devise))
                        {
                            double taux = rates[Devise];
                            TauxConversion = taux;
                        }
                        else
                        {
                            TauxConversion = -1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Erreur lors de la récupération des données.");
                    TauxConversion = -1;
                }
            }
        }


        // Méthode pour afficher les informations de la transaction
        public void AfficherTransaction()
        {
            Console.WriteLine($"Numéro CB : {NumeroCarteBancaire}, Type : {Type}, Montant : {Montant} {Devise}, Date : {Date}");
        }
    }

}
