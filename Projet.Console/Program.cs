using Projet.BDD.Entities.Serveur;
using Projet.Console;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
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
}
