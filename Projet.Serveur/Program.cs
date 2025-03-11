using Projet.BDD.Entities.Serveur;
using Projet.Business.Dto;
using Projet.Serveur.Generation;
using Projet.Serveur.Traitement;
using System.Buffers;
using System.Text.Json;
using System.Transactions;
using Projet.Serveur.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var controllerAno = new EnregistrementController();
        var controllerEnr = new AnomalieController();

        string filename = @"C:\Users\bosso\Documents\Thierry\Ajc_formation\c#\Projet .Net\projet\Projet-.Net-Groupe-5\Projet.Serveur\json\test.json";
        List<Operation> operations = CreateOperations(10);
        WriteOperationsToFile(operations, filename);
        AddOperationFromFileAsync(filename);



    }
    private static List<Operation> CreateOperations(int nb)
    {
        List<Operation> operations = new List<Operation>();

        for (int i = 0; i < nb; i++)
        {
            operations.Add(new Operation());
        }

        return operations;
    }

    private static void WriteOperationsToFile(List<Operation> operations, string filename)
    {
        string jsonString = JsonSerializer.Serialize(operations, new JsonSerializerOptions { WriteIndented = true });

        using (FileStream jsonfs = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(jsonfs, operations, new JsonSerializerOptions { WriteIndented = true });
        }

        Console.WriteLine($"Fichier JSON '{filename}' créé avec succès.");
    }

    private static async Task AddOperationFromFileAsync(string filepath)
    {
        var controllerEnr = new EnregistrementController();
        var controllerAno = new AnomalieController();
        string jsonString = File.ReadAllText(filepath);
        
        List<Operation> operations = JsonSerializer.Deserialize<List<Operation>>(jsonString);
        Random rand = new Random();

        foreach (Operation op in operations)
        {
            op.AfficherTransaction();
            Console.WriteLine();
            if (VerifOperation.CheckOperation(op))
            {
                var enregistrement = new EnregistrementDto
                {
                    NumeroCarteBancaire = op.NumeroCarteBancaire,
                    MontantOperation = op.Montant,
                    TypeOperation = (Projet.Business.Dto.Serveur.EnumOperation)op.Type,  // Casting Enum
                    DateOperation = op.Date,
                    Devise = op.Devise
                };
                
                Console.WriteLine("insertion enregistrement");
                await controllerEnr.AddEnregistrement(enregistrement);
                
            }
            else
            {
                var anomalie = new AnomalieDto
                {
                    NumeroCarteBancaire = op.NumeroCarteBancaire,
                    MontantOperation = op.Montant,
                    TypeOperation = (Projet.Business.Dto.Serveur.EnumOperation)op.Type,
                    DateOperation = op.Date,
                    Devise = op.Devise,
                    Erreur = "Opération non valide selon les règles de vérification." // Message d'erreur par défaut
                };
                Console.WriteLine("insertion anomalie");
                await controllerAno.AddAnomalie(anomalie);
               

            }
           
           
        }
    }

}