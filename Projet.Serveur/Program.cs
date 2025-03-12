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
        //chemins fichiers
        string filename = @"..\..\..\json\Operations.json";
        string filename2 = @"..\..\..\..\Projet.Serveur.Extract\extract\extractEnregistrements.json";

        //création de 10 opérations aléatoires
        List<Operation> operations = CreateOperations(10);

        //écriture des opérations sur le fichier qui sera traité
        WriteToFile(operations, filename);

        //traitement et insertion des enregistrements/anomalies
        AddOperationFromFileAsync(filename);

        //création du fichier extract utilisé par le client
        CreateFileFromDatabase(filename2);



    }
    //crée un nombre d'opérations spécifié par le paramètre nb
    private static List<Operation> CreateOperations(int nb)
    {
        List<Operation> operations = new List<Operation>();
       

        for (int i = 0; i < nb; i++)
        {
            operations.Add(new Operation());
        }

        return operations;
    }

    //écrit un object sous forme de json dans le fichier donné en paramètre
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

    //Trie et insère les opérations dans la base de données depuis un fichier
    private static async Task AddOperationFromFileAsync(string filepath)
    {
        string jsonString = File.ReadAllText(filepath);

        //liste opérations renseignéees sur le fichier
        List<Operation> operations = JsonSerializer.Deserialize<List<Operation>>(jsonString);

        foreach (Operation op in operations)
        {
            //si l'opération est valide
            if (VerifOperation.CheckOperation(op))
            {
                //crée un enregistrement et l'insère dans la base de données
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
                //crée une anomalie et l'insère dans la base de données
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

        //Encapsule la liste pour avoir un tritre "Enregistrements" sur le fichier Json
        var JsonEnregistrement = new
        {
            Enregistrements = enregistrements // Liste récupérée
        };
        WriteToFile(JsonEnregistrement, filepath);

    }

}