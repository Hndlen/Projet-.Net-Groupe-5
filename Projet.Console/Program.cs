using Microsoft.EntityFrameworkCore;
using Projet.BDD;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.Console.InfoJSON;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static string GenererNumeroCompte(DateTime dateOuverture)
    {
        // Générer un numéro de compte basé sur la date
        string date = dateOuverture.ToString("yyyy MMdd");
        string compte = "1234";  // Remplacer par une valeur fixe ou générée

        return $"HNTB-{date}-{compte}";
    }
    public static void NouveauCompteBancaire()
    {

        using (var context = new MyDbContextConsole())
        {
            // Appliquer les migrations à la base de données
            context.Database.Migrate();  // Cela applique toutes les migrations en attente

            // Maintenant, initialise les données après la migration
            DateTime dateOuverture = new DateTime(2000, 11, 12);
            string numeroCompteTest = GenererNumeroCompte(dateOuverture);

            // Ajouter ces données dans la base de données
            context.ComptesBancaire.Add(new CompteBancaire
            {
                Numero = numeroCompteTest,
                DateOuverture = dateOuverture,
                Solde = 1000,
                ClientId = 1
            });
            
            

            // Sauvegarder les modifications dans la base de données
            context.SaveChanges();
        }
    }
    
    static async void LectureJSON()
    {
        //string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "ExportJSON", "export.json");
        //string filePath = @"C:\Users\lhand\source\repos\Projet-.Net-Groupe-5\Projet.Console\ExportJSON";
        string filePath = @"C:\Users\lhand\Source\Repos\Projet-.Net-Groupe-5\Projet.Console\jsontest.json";

        string jsonString = File.ReadAllText(filePath);
        bool Signe = true;
        try
        {
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                // Extraction du tableau "Enregistrements" dans le JSON
                JsonElement root = doc.RootElement;
                if (root.TryGetProperty("Enregistrements", out JsonElement enregistrementsElement))
                {
                    // Désérialisation directement en List<Enregistrement>
                    var enregistrements = JsonSerializer.Deserialize<List<EnregistrementJSON>>(enregistrementsElement.GetRawText());

                    // Affichage des données
                    foreach (var enregistrement in enregistrements)
                    {
                        Console.WriteLine($"ID: {enregistrement.Id}");
                        Console.WriteLine($"Numéro de Carte Bancaire: {enregistrement.NumeroCarteBancaire}");
                        Console.WriteLine($"Montant de l'Opération: {enregistrement.MontantOperation}");
                        Console.WriteLine($"Type d'Opération: {enregistrement.TypeOperation}");
                        Console.WriteLine($"Date de l'Opération: {enregistrement.DateOperation}");
                        Console.WriteLine($"Devise: {enregistrement.Devise}");
                        Console.WriteLine();

                        if(enregistrement.TypeOperation == "Depot")
                        {
                            Console.WriteLine("DEPOT");
                            Signe = true;
                            GetCartesByNumero(enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation,Signe);
                        }
                        else if(enregistrement.TypeOperation == "Retrait")
                        {
                            Console.WriteLine("RETRAIT");
                            Signe = false;
                            GetCartesByNumero(enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation, Signe);
                        }
                        else
                        {
                            Console.WriteLine("FACTURE");
                        }
                            
                            Console.WriteLine("__________________________________________________________");
                    }
                }
                else
                {
                    Console.WriteLine("Le JSON ne contient pas la clé 'Enregistrements'.");
                }
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erreur de désérialisation JSON: {ex.Message}");
        }
    }

    static async void GetAllClient()
    {
        //string url = "http://localhost:5155/api/Products/";
        string url = "http://localhost:5187/api/Clients/all/";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"{url}").Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonInfo = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonInfo);
                var objInfo = JsonSerializer.Deserialize<List<ClientJSON>>(jsonInfo);
                foreach (var o in objInfo)
                {
                    Console.WriteLine($"{o.Id} {o.Nom} {o.AdresseClientId} {o.AdresseClient} {o.Mail} {o.Type} {o.CompteBancaire}");
                }
                
            }
            else
            {
                Console.WriteLine($"Err not found");
            }
        }
    }

    static async Task GetClientById(int id)
    {
        string url = $"http://localhost:5187/{id}";
        Console.WriteLine("test1");
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine("test2");
                HttpResponseMessage response = client.GetAsync($"{url}").Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("test3");
                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(jsonInfo);
                    //var clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var clientInfo = JsonSerializer.Deserialize<ClientJSON>(jsonInfo);

                    Console.WriteLine($"ID: {clientInfo.Id}");
                    Console.WriteLine($"Nom: {clientInfo.Nom}");
                    //Console.WriteLine($"Email: {clientInfo.Email}");
                    //Console.WriteLine($"Téléphone: {clientInfo.Telephone}");
                }
                else
                {
                    Console.WriteLine($"❌ Erreur : Client avec ID {id} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la récupération : {ex.Message}");
            }
            Console.WriteLine("test4");
        }
        Console.WriteLine("test5");
    }

    static async Task GetCartesByNumero(string numero,double montant,bool Signe)
    {
        string url = $"http://localhost:5187/api/CartesBancaire/{numero}";
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                
                HttpResponseMessage response = client.GetAsync($"{url}").Result;

                if (response.IsSuccessStatusCode)
                {
                    
                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(jsonInfo);
                    //var clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var carteInfo = JsonSerializer.Deserialize<CarteBancaireJSON>(jsonInfo);

                    Console.WriteLine($"ID: {carteInfo.Numero}");
                    Console.WriteLine($"Nom: {carteInfo.CompteCarteId}");
                    Console.WriteLine();
                    double NouveauSolde = montant * (Signe ? 1 : -1);
                    //GetCartesByNumero(carteInfo.CompteCarteId);
                    PutCompteByNumeroAndMontant(carteInfo.CompteCarteId, NouveauSolde);
                    
                }
                else
                {
                    Console.WriteLine($"❌ Erreur : Client avec ID {numero} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la récupération : {ex.Message}");
            }
            
        }
        
    }

    static async Task GetCompteByNumero(string numero)
    {
        string url = $"http://localhost:5187/api/ComptesBancaire/{numero}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {

                HttpResponseMessage response = client.GetAsync($"{url}").Result;

                if (response.IsSuccessStatusCode)
                {

                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    var compteInfo = JsonSerializer.Deserialize<CompteBancaireJSON>(jsonInfo);

                    Console.WriteLine($"ID: {compteInfo.Numero}");
                    Console.WriteLine($"Nom: {compteInfo.Solde}");

                }
                else
                {
                    Console.WriteLine($"❌ Erreur : Client avec ID {numero} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la récupération : {ex.Message}");
            }

        }

    }
    static async Task PutCompteByNumeroAndMontant(string numero, double montant)
    {
        string url = $"http://localhost:5187/api/ComptesBancaire/{numero},{montant}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var testDT = new
            {
                CompteCarteId = numero,
                Montant = montant
            };
            string jsonData = JsonSerializer.Serialize(testDT);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {

                //HttpResponseMessage response = client.GetAsync($"{url}").Result;
                HttpResponseMessage response =  client.PutAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"✅ Mise à jour réussie pour la carte {numero} avec un montant de {montant}");
                }
                else
                {
                    Console.WriteLine($"❌ Erreur : Impossible de mettre à jour la carte {numero}. Code : {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la mise à jour : {ex.Message}");
            }

        }

    }


    private static void Main(string[] args)
    {
        LectureJSON();
        //GetAllClient();
        Console.WriteLine("__");
        //GetCartesByNumero("4974 0185 0223 0007");
        //GetClientById(1);
        //NouveauCompteBancaire();
        Console.WriteLine("Fini");
    }
}
