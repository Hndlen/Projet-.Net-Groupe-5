using Projet.Serveur.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Serveur.Traitement
{
    public static class VerifOperation
    {
        public static bool CheckOperation(Operation op)
        {
            if (!Enum.IsDefined(typeof(EnumOperation), op.Type))
            {
                Console.WriteLine("Opération de type invalide.");
                return false;
            }


            if (op.Montant == 0)
            {
                Console.WriteLine("Le montant ne peut pas être nul.");
                return false;
            }
            if (op.Montant > 0 && op.Type == EnumOperation.Retrait || op.Montant > 0 && op.Type == EnumOperation.Facture)
            {
                Console.WriteLine("Un retrait ou une facture ne peut pas avoir un montant positif.");
                return false;
            }

            if (op.Montant < 0 && op.Type == EnumOperation.Depot)
            {
                Console.WriteLine("Un dépôt ne peut pas avoir un montant négatif.");
                return false;
            }

            return CheckCB(op.NumeroCarteBancaire);

        }
        private static bool CheckCB(string numeroCarteBancaire)
        {

            numeroCarteBancaire = numeroCarteBancaire.Replace(" ", "");

            // Initialiser la somme
            int somme = 0;
            bool paire = false; // Démarre à la fin du numéro (donc on commence à doubler à partir de l'avant-dernier chiffre)

            // Parcourir le numéro de carte de droite à gauche
            for (int i = numeroCarteBancaire.Length - 1; i >= 0; i--)
            {
                int chiffre = int.Parse(numeroCarteBancaire[i].ToString());

                // Si la position est une position à doubler
                if (paire)
                {
                    chiffre *= 2;
                    // Si le résultat est supérieur ou égal à 10, on additionne les chiffres du produit
                    if (chiffre >= 10)
                    {
                        somme += (chiffre - 9); // Ce qui est équivalent à additionner les chiffres du produit
                    }
                    else
                    {
                        somme += chiffre;
                    }
                }
                else
                {
                    somme += chiffre;
                }

                // Alterner entre doubler et ne pas doubler
                paire = !paire;
            }

            // Si la somme est divisible par 10, le numéro de carte est valide
            return (somme % 10 == 0);
        }



    }

}