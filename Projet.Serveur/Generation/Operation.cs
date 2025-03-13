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

        
        private static Random random = new Random();

        // Constructeur, initialise les attributs via les méthodes
        public Operation()
        {
            SetNumeroCarteBancaire();
            SetType();
            SetMontant();
            Date = DateTime.Now;  // Date d'aujourd'hui
            SetDevise();
            SetTauxConvertion();
        }

        //  choisi un numéro de carte bancaire aléatoirement
        private void SetNumeroCarteBancaire()
        {
            //string numeroCB = "4000 0000 0000 1091";
            String[] numsCB = {
                "4974 0185 0223 9888",
                "4974 0185 0223 7320",
                "4974 0185 0223 0457",
                "4974 0185 0223 0952",
                "4974 0185 0223 5142",
                "4974 0185 0223 7874",
                "4974 0185 0223 8476",
                "4974 0185 0223 8666",
                "4974 0185 0223 3469",
                "4974 0185 0223 6090",
                "4974 0185 0223 7411",
                "4974 0185 0223 2842",
                "4974 0185 0223 5720",
                "4974 0185 0223 4814",
                "4974 0185 0223 4871",
                "4974 0185 0223 9763",
                "4974 0185 0223 4555",  // Mauvais dernier chiffre
                "4974 0185 0223 9144",  // Mauvais dernier chiffre
                "4974 0185 0223 2370",  // Mauvais dernier chiffre
                "4974 0185 0223 6249",  // Mauvais dernier chiffre
                "4974 0185 0223 0895"   // Mauvais dernier chiffre
            };

            int index = random.Next(numsCB.Length);
            this.NumeroCarteBancaire = numsCB[index];
        }

        // génère un montant aléatoire
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

        // choisi une devise aléatoirement
        private void SetDevise()
        {
            string[] devises = { "EUR", "USD", "CAD", "JPY", "CNY", "???" };
            int index = random.Next(devises.Length);
            this.Devise = devises[index];
        }

        // choisi un type d'opération aléatoirement
        private void SetType()
        {
            Array types = Enum.GetValues(typeof(EnumOperation));
            this.Type = (EnumOperation)types.GetValue(random.Next(types.Length));
        }

        //récupère le taux de convertion et l'affecte à l'attribut TauxConversion
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



    }

}
