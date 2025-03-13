using Microsoft.EntityFrameworkCore;
using Projet.BDD;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.Console.Authentification;
using Projet.Console.ExtractionsXML;
using Projet.Console.InfoJSON;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    //
    
    static class NumeroCompteGlobal
    {
        public static string numeroCompte = "";
    }


    /*
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
    }*/

    static async void LectureJSON()
    {
        string filePath = @"C:\Users\lhand\Source\Repos\Projet-.Net-Groupe-5\Projet.Console\jsontest.json";

        string jsonString = File.ReadAllText(filePath);
        bool Signe = true;
        double montantConvert = 0;
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
                        
                        Console.WriteLine(">>> LECTURE JSON");
                        Console.WriteLine($"ID: {enregistrement.Id}");
                        Console.WriteLine($"Numéro de Carte Bancaire: {enregistrement.NumeroCarteBancaire}");
                        Console.WriteLine($"Montant de l'Opération: {enregistrement.MontantOperation}");
                        Console.WriteLine($"Type d'Opération: {enregistrement.TypeOperation}");
                        Console.WriteLine($"Date de l'Opération: {enregistrement.DateOperation}");
                        Console.WriteLine($"Devise: {enregistrement.Devise}");
                        Console.WriteLine();
                        
                        if (enregistrement.TypeOperation == 0)
                        {
                            Console.WriteLine("DEPOT");
                            
                            
                        }
                        else if(enregistrement.TypeOperation == 1)
                        {
                            Console.WriteLine("RETRAIT");
                            
                            
                        }
                        else
                        {
                            Console.WriteLine("FACTURE");
                        }
                        GetCartesByNumero(enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation, Signe);

                        if (enregistrement.tauxConvertion != 1)
                        {
                            montantConvert = enregistrement.MontantOperation / enregistrement.tauxConvertion;
                            montantConvert = Math.Truncate(montantConvert * 100) / 100;

                        }
                        else
                        {
                            montantConvert = enregistrement.MontantOperation;
                        }

                            Transactions(NumeroCompteGlobal.numeroCompte, enregistrement.NumeroCarteBancaire, montantConvert, enregistrement.TypeOperation, enregistrement.DateOperation, enregistrement.Devise);
                        
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
                    Console.WriteLine(">>> LECTURE Carte Bancaire par ID");
                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(jsonInfo);
                    //var clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var carteInfo = JsonSerializer.Deserialize<CarteBancaireJSON>(jsonInfo);

                    Console.WriteLine($"ID: {carteInfo.Numero}");
                    Console.WriteLine($"Nom: {carteInfo.CompteCarteId}");
                    Console.WriteLine();
                    double NouveauSolde = montant * (Signe ? 1 : -1);
                    //Console.WriteLine("test1");
                    NumeroCompteGlobal.numeroCompte = carteInfo.CompteCarteId;
                    GetCompteByNumero(carteInfo.CompteCarteId);
                    //Console.WriteLine("test2");
                    PutCompteByNumeroAndMontant(carteInfo.CompteCarteId, NouveauSolde);
                    
                }
                else
                {
                    Console.WriteLine($"Erreur : Client avec ID {numero} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération : {ex.Message}");
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
                    Console.WriteLine(">>> Get Compte Bancaire par Carte");
                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    var compteInfo = JsonSerializer.Deserialize<CompteBancaireJSON>(jsonInfo);

                    Console.WriteLine($"ID: {compteInfo.Numero}");
                    Console.WriteLine($"Montant: {compteInfo.Solde}");

                }
                else
                {
                    Console.WriteLine($"Erreur : Client avec ID {numero} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération : {ex.Message}");
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
                Console.WriteLine(">>> Put Compte Bancaire par Carte");
                //HttpResponseMessage response = client.GetAsync($"{url}").Result;
                HttpResponseMessage response =  client.PutAsync(url, content).Result;
                //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{response.ToString()}{Environment.NewLine}{Environment.NewLine}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Mise à jour réussie pour la carte {numero} avec un montant de {montant}");
                }
                else
                {
                    Console.WriteLine($"Erreur : Impossible de mettre à jour la carte {numero}. Code : {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
            }

        }

    }
    static async Task GetTransactionByPeriode(string numero, string dateDebut, string dateFin)
    {
        string url = $"http://localhost:5187/{dateDebut}/{dateFin}/{numero}";
        //string url = $"http://localhost:5187/{dateDebut}/{dateFin}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {

                HttpResponseMessage response = client.GetAsync($"{url}").Result;

                if (response.IsSuccessStatusCode)
                {

                    string jsonInfo = response.Content.ReadAsStringAsync().Result;
                    var objInfo = JsonSerializer.Deserialize<List<TransactionJSON>>(jsonInfo);
                    foreach (var o in objInfo)
                    {
                        Console.WriteLine($"{o.Id} {o.NumeroCarteBancaire} {o.MontantOperation}");
                        Console.WriteLine();
                    }


                }
                else
                {
                    Console.WriteLine(response);
                    Console.WriteLine($"Erreur : Client avec ID {numero} non trouvé.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération : {ex.Message}");
            }

        }

    }
    static string LireMotDePasse()
    {
        string motDePasse = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(intercept: true); // Ne pas afficher la touche tapée

            if (key.Key != ConsoleKey.Enter)
            {
                motDePasse += key.KeyChar;
                Console.Write("*"); // Affiche un astérisque à la place
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return motDePasse;
    }

    static void Authentification()
    {
        Connexion co = new Connexion();
        bool estAuthentifie = false;
        while (estAuthentifie == false)
        {
            Console.Write("Nom d'utilisateur : ");
            string username = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string password = LireMotDePasse();
            estAuthentifie = co.Login(username, password);
            if (estAuthentifie)
            {
                Console.WriteLine("\nConnexion réussie !");
            }
            else
            {
                Console.WriteLine("\nIdentifiants incorrects !");
            }
        }
    }

    static void Transactions(string NumeroCompte,string numeroCarteBancaire,double montantOperation,int typeOperation,string dateOperation,string devise)
    {
        using (var context = new MyDbContextConsole())
        {
            // Appliquer les migrations à la base de données
            context.Database.Migrate();  // Cela applique toutes les migrations en attente

            // Maintenant, initialise les données après la migration
            //DateTime dateOuverture = new DateTime(2000, 11, 12);
            //string numeroCompteTest = GenererNumeroCompte(dateOuverture);
            //DateTime date = DateTime.ParseExact(dateOperation, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime dateTime = DateTime.Parse(dateOperation);
            DateTime date = DateTime.ParseExact(dateTime.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            // Ajouter ces données dans la base de données
            context.TransactionsHistoriques.Add(new TransactionsHistorique
            {
                CompteCarteId = NumeroCompte,
                NumeroCarteBancaire = numeroCarteBancaire,
                MontantOperation = montantOperation,
                TypeOperation = typeOperation.ToString(),
                DateOperation = date,
                Devise = "EU"

            });



            // Sauvegarder les modifications dans la base de données
            context.SaveChanges();
        }
    }
    private static void Main(string[] args)
    {

        //Authentification();

        LectureJSON();
        /*
        string filePath = "C:\\Users\\lhand\\Source\\Repos\\Projet-.Net-Groupe-5\\Projet.Console\\ExtractionsXML\\personnes.xml"; // Chemin du fichier XML
        ExtractionXML.CreerXml(filePath);

        string filePath2 = "C:\\Users\\lhand\\Source\\Repos\\Projet-.Net-Groupe-5\\Projet.Console\\ExtractsPDF\\mon_document.pdf"; // Nom du fichier PDF
        string texte = "Bonjour, ceci est un fichier PDF généré en C#!";

        PdfCreator.CreerPdf(filePath2, texte);*/
        //GetAllClient();
        //DateTime Debut =  new DateTime(2000, 11, 12);
        //DateTime Fin = new DateTime(2026, 11, 12);
        /*string dateString = "2025-03-12";
        DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        Console.WriteLine(date);
        Console.WriteLine(Debut);
        Console.WriteLine(Fin);*/
        //string Debut = "2000-10-10";
       // string Fin = "2030-10-10";
        //GetTransactionByPeriode("4974 0185 0223 4053",Debut,Fin );

        Console.WriteLine("__");
        //GetCartesByNumero("4974 0185 0223 0007");
        //GetClientById(1);
        //NouveauCompteBancaire();
        Console.WriteLine("Fini");
    }
}
