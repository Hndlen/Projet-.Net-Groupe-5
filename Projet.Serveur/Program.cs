using Projet.Serveur.Generation;
using Projet.Serveur.Traitement;
using System.Buffers;
using System.Text.Json;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        string filename = @"C:\Users\bosso\Documents\Thierry\Ajc_formation\c#\Projet .Net\projet\Projet-.Net-Groupe-5\Projet.Serveur\json\test.json";
        List<Operation> operations = CreateOperations(10);
        WriteOperationsToFile(operations, filename);

        foreach(Operation  op in operations )
        {
            Console.WriteLine(VerifOperation.CheckOperation(op));
        }

        
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
}