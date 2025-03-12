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
    static EnregistrementController controllerEnr = new EnregistrementController();
    static AnomalieController controllerAno = new AnomalieController();
    private static void Main(string[] args)
    {

        string filename = @"..\..\..\json\Operations.json";
        string filename2 = @"..\..\..\..\Projet.Serveur.Extract\extract\extractEnregistrements.json";

        List<Operation> operations = CreateOperations(10);
        WriteToFile(operations, filename);
        AddOperationFromFileAsync(filename);
        CreateFileFromDatabase(filename2);



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

    private static void WriteToFile<T>(T data, string filename)
    {
        // Sérialisation de l'objet en JSON
        string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        // Écriture dans le fichier
        using (FileStream jsonfs = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(jsonfs, data, new JsonSerializerOptions { WriteIndented = true });
        }

        Console.WriteLine($"Fichier JSON '{filename}' créé avec succès.");
    }


    private static async Task AddOperationFromFileAsync(string filepath)
    {
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
                    tauxConvertion = op.TauxConversion,
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
                    tauxConvertion = op.TauxConversion,
                    Erreur = VerifOperation.LastError // Message d'erreur par défaut
                };
                Console.WriteLine("insertion anomalie");
                await controllerAno.AddAnomalie(anomalie);


            }


        }
    }
    private static void CreateFileFromDatabase(string filepath)
    {
        var enregistrements = controllerEnr.GetEnregistrementsBydate(DateTime.Now).Result;
        var anomalies = controllerAno.GetAnomalies().Result;
        Console.WriteLine(anomalies);

        WriteToFile(enregistrements, filepath);

    }

}