using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Console.Authentification
{
    public class Connexion
    {
        private static Dictionary<string, string> utilisateurs = new Dictionary<string, string>
        {
            { "a", "a" },
            { "admin", "password" },
            { "steeve", "assous" },
            { "thierry", "bossou" },
            { "nathaniel", "handalena" }
        };

        public bool Login(string username, string password)
        {
            // Vérifie si l'utilisateur existe et que le mot de passe est correct
            return utilisateurs.ContainsKey(username) && utilisateurs[username] == password;
            
        }

        /*static string LireMotDePasse()
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
        }*/
    }
}
