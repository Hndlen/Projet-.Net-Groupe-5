using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.Console.InfoJSON;
using System.Text.Json;

internal class Program
{
    static async void LectureJSON()
    {
        //string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "ExportJSON", "export.json");
        //string filePath = @"C:\Users\lhand\source\repos\Projet-.Net-Groupe-5\Projet.Console\ExportJSON";
        string filePath = @"C:\Users\lhand\Source\Repos\Projet-.Net-Groupe-5\Projet.Console\jsontest.json";

        string jsonString = File.ReadAllText(filePath);

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

    /*static async Task GetClientById(int id)
    {
        string url = $"http://localhost:5187/api/Clients/{id}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonInfo = await response.Content.ReadAsStringAsync();
                    Client clientInfo = JsonSerializer.Deserialize<Client>(jsonInfo, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    Console.WriteLine($"ID: {clientInfo.Id}");
                    Console.WriteLine($"Nom: {clientInfo.Nom}");
                    Console.WriteLine($"Email: {clientInfo.Email}");
                    Console.WriteLine($"Téléphone: {clientInfo.Telephone}");
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
        }
    }*/


    private static void Main(string[] args)
    {
        LectureJSON();
        GetAllClient();
    }
}
