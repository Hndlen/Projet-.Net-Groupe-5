using Projet.BDD.Entities.Console;
using Projet.BDD;
using Projet.Console.Authentification;
using Projet.Console.InfoJSON;
using System.Globalization;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projet.Fenetre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //*-*********************************************************************
        static class NumeroCompteGlobal
        {
            public static string numeroCompte = "";
        }
        static class RecapJSON
        {
            public static string recapJSON = "";
        }
        static async void LectureJSON()
        {
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

                           /* Console.WriteLine(">>> LECTURE JSON");
                            Console.WriteLine($"ID: {enregistrement.Id}");
                            Console.WriteLine($"Numéro de Carte Bancaire: {enregistrement.NumeroCarteBancaire}");
                            Console.WriteLine($"Montant de l'Opération: {enregistrement.MontantOperation}");
                            Console.WriteLine($"Type d'Opération: {enregistrement.TypeOperation}");
                            Console.WriteLine($"Date de l'Opération: {enregistrement.DateOperation}");
                            Console.WriteLine($"Devise: {enregistrement.Devise}");
                            Console.WriteLine();*/

                            if (enregistrement.TypeOperation == "Depot")
                            {
                             //   Console.WriteLine("DEPOT");
                                Signe = true;
                                GetCartesByNumero(enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation, Signe);
                            }
                            else if (enregistrement.TypeOperation == "Retrait")
                            {
                             //   Console.WriteLine("RETRAIT");
                                Signe = false;
                                GetCartesByNumero(enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation, Signe);
                            }
                            else
                            {
                              //  Console.WriteLine("FACTURE");
                            }
                            Transactions(NumeroCompteGlobal.numeroCompte, enregistrement.NumeroCarteBancaire, enregistrement.MontantOperation, enregistrement.TypeOperation, enregistrement.DateOperation, enregistrement.Devise);
                           // Console.WriteLine("__________________________________________________________");
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Le JSON ne contient pas la clé 'Enregistrements'.");
                    }
                }
            }
            catch (JsonException ex)
            {
               // Console.WriteLine($"Erreur de désérialisation JSON: {ex.Message}");
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
                   // Console.WriteLine(jsonInfo);
                    var objInfo = JsonSerializer.Deserialize<List<ClientJSON>>(jsonInfo);
                    foreach (var o in objInfo)
                    {
                        //Console.WriteLine($"{o.Id} {o.Nom} {o.AdresseClientId} {o.AdresseClient} {o.Mail} {o.Type} {o.CompteBancaire}");
                    }

                }
                else
                {
                   // Console.WriteLine($"Err not found");
                }
            }
        }

        static async Task GetClientById(int id)
        {
            string url = $"http://localhost:5187/{id}";
           // Console.WriteLine("test1");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //Console.WriteLine("test2");
                    HttpResponseMessage response = client.GetAsync($"{url}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                       // Console.WriteLine("test3");
                        string jsonInfo = response.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(jsonInfo);
                        //var clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var clientInfo = JsonSerializer.Deserialize<ClientJSON>(jsonInfo);

                        //Console.WriteLine($"ID: {clientInfo.Id}");
                        //Console.WriteLine($"Nom: {clientInfo.Nom}");
                        //Console.WriteLine($"Email: {clientInfo.Email}");
                        //Console.WriteLine($"Téléphone: {clientInfo.Telephone}");
                    }
                    else
                    {
                       // Console.WriteLine($"❌ Erreur : Client avec ID {id} non trouvé.");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"❌ Erreur lors de la récupération : {ex.Message}");
                }
                //Console.WriteLine("test4");
            }
            //Console.WriteLine("test5");
        }

        static async Task GetCartesByNumero(string numero, double montant, bool Signe)
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
                        //Console.WriteLine(">>> LECTURE Carte Bancaire par ID");
                        string jsonInfo = response.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(jsonInfo);
                        //var clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var carteInfo = JsonSerializer.Deserialize<CarteBancaireJSON>(jsonInfo);

                        //Console.WriteLine($"ID: {carteInfo.Numero}");
                       // Console.WriteLine($"Nom: {carteInfo.CompteCarteId}");
                        //Console.WriteLine();
                        double NouveauSolde = montant * (Signe ? 1 : -1);
                        //Console.WriteLine("test1");
                        NumeroCompteGlobal.numeroCompte = carteInfo.CompteCarteId;
                        GetCompteByNumero(carteInfo.CompteCarteId);
                        //Console.WriteLine("test2");
                        PutCompteByNumeroAndMontant(carteInfo.CompteCarteId, NouveauSolde);

                    }
                    else
                    {
                        //Console.WriteLine($"Erreur : Client avec ID {numero} non trouvé.");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Erreur lors de la récupération : {ex.Message}");
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
                        //Console.WriteLine(">>> Get Compte Bancaire par Carte");
                        string jsonInfo = response.Content.ReadAsStringAsync().Result;
                        var compteInfo = JsonSerializer.Deserialize<CompteBancaireJSON>(jsonInfo);

                        //Console.WriteLine($"ID: {compteInfo.Numero}");
                        //Console.WriteLine($"Montant: {compteInfo.Solde}");

                    }
                    else
                    {
                        //Console.WriteLine($"Erreur : Client avec ID {numero} non trouvé.");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Erreur lors de la récupération : {ex.Message}");
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
                    //Console.WriteLine(">>> Put Compte Bancaire par Carte");
                    //HttpResponseMessage response = client.GetAsync($"{url}").Result;
                    HttpResponseMessage response = client.PutAsync(url, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //Console.WriteLine($"Mise à jour réussie pour la carte {numero} avec un montant de {montant}");
                    }
                    else
                    {
                        //Console.WriteLine($"Erreur : Impossible de mettre à jour la carte {numero}. Code : {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
                }

            }

        }

        

        static void Transactions(string NumeroCompte, string numeroCarteBancaire, double montantOperation, string typeOperation, string dateOperation, string devise)
        {
            using (var context = new MyDbContextConsole())
            {
                // Appliquer les migrations à la base de données
                context.Database.Migrate();  // Cela applique toutes les migrations en attente

                // Maintenant, initialise les données après la migration
                //DateTime dateOuverture = new DateTime(2000, 11, 12);
                //string numeroCompteTest = GenererNumeroCompte(dateOuverture);
                DateTime date = DateTime.ParseExact(dateOperation, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                // Ajouter ces données dans la base de données
                context.TransactionsHistoriques.Add(new TransactionsHistorique
                {
                    CompteCarteId = NumeroCompte,
                    NumeroCarteBancaire = numeroCarteBancaire,
                    MontantOperation = montantOperation,
                    TypeOperation = typeOperation,
                    DateOperation = date,
                    Devise = devise

                });



                // Sauvegarder les modifications dans la base de données
                context.SaveChanges();
            }

            string recap = $"NumCompte:{NumeroCompte} NumCarte:{numeroCarteBancaire} MontantOp:{montantOperation} TypeOp:{typeOperation} DateOp:{dateOperation} Devise:{devise}\r\n";
            RecapJSON.recapJSON += recap;
        }

       /* public void majRecapJSON(string recap)
        {
            textBoxRecapMajJSON.Text += recap;
        }*/
        //*-*********************************************************************
        private void listeDesMouvementsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //textBox1.Text = "LOGIN";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            Connexion co = new Connexion();
            bool estAuthentifie = false;
            if (estAuthentifie == false)
            {

                estAuthentifie = co.Login(textBoxIdentifiant.Text, textBoxMotDePasse.Text);
                if (estAuthentifie)
                {
                    //Console.WriteLine("\nConnexion réussie !");
                    labelAuthentification.Visible = true;
                    labelAuthentification.Text = "Connexion réussie !";
                    mAJJsonToolStripMenuItem.Enabled = true;
                    listeDesMouvementsPDFToolStripMenuItem.Enabled = true;
                    recapitulationDesOpérationsXMLToolStripMenuItem.Enabled = true;
                    textBoxIdentifiant.Enabled = false;
                    textBoxMotDePasse.Enabled = false;
                    logginToolStripMenuItem.Enabled = false;
                }
                else
                {
                    labelAuthentification.Visible = true;
                    labelAuthentification.Text = "Identifiants incorrects !";
                    textBoxIdentifiant.Text = "";
                    textBoxMotDePasse.Text = "";
                    // Console.WriteLine("\nIdentifiants incorrects !");
                }
                // UserControl =
                //textBoxIdentifiant.Text = "test";
                //textBoxMotDePasse.Text = textBoxIdentifiant.Text;
            }
        }

        private void mAJJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            labelAuthentification.Visible = false;
            panelMajJSON.Visible = true;
        }

        private void buttonMajJSON_Click(object sender, EventArgs e)
        {
            textBoxRecapMajJSON.Text = "lecture en cours...";
            LectureJSON();
            textBoxRecapMajJSON.Text = RecapJSON.recapJSON;
            labelMajJSON.Text = " Lecture fini, mise à jour de la balance";
            mAJJsonToolStripMenuItem.Enabled = false;
        }
    }
}
