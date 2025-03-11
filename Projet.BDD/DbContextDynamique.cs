using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD
{
    public class DbContextDynamique 
    {
        public static void InitialiserDonnees(MyDbContextConsole context)
        {
            // Exemple de données à insérer
            DateTime dateOuverture = new DateTime(2000, 11, 12);
            string numeroCompte = GenererNumeroCompte(dateOuverture);

            // Ajouter ces données dans la base de données
            context.ComptesBancaire.Add(new CompteBancaire
            {
                Numero = numeroCompte,
                DateOuverture = dateOuverture,
                Solde = 1000,
                ClientId = 1
            });

            // Sauvegarder les modifications dans la base de données
            context.SaveChanges();
        }

        public static string GenererNumeroCompte(DateTime dateOuverture)
        {
            // Générer un numéro de compte basé sur la date
            string date = dateOuverture.ToString("yyyy MMdd");
            string compte = "1234";  // Remplacer par une valeur fixe ou générée

            return $"HNTB-{date}-{compte}";
        }
    }
}

