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
        //variable statique pour récupérer la dernière erreur obtenue
        public static string LastError { get; set; }

        //vérifie si l'opération est valide
        public static bool CheckOperation(Operation op)
        {
            if (!Enum.IsDefined(typeof(EnumOperation), op.Type))
            {
                LastError = "Opération de type invalide.";
                return false;
            }

            if (op.Montant == 0)
            {
                LastError = "Le montant ne peut pas être nul.";
                return false;
            }
            if (op.Montant > 0 && op.Type == EnumOperation.Retrait || op.Montant > 0 && op.Type == EnumOperation.Facture)
            {
                LastError = "Un retrait ou une facture ne peut pas avoir un montant positif.";
                return false;
            }

            if (op.Montant < 0 && op.Type == EnumOperation.Depot)
            {
                LastError = "Un dépôt ne peut pas avoir un montant négatif.";
                return false;
            }

            if (op.TauxConversion < 0)
            {
                LastError = "La devise est incorrecte.";
                return false;
            }

            return CheckCB(op.NumeroCarteBancaire);

        }
        private static bool CheckCB(string numeroCarteBancaire)
        {

            numeroCarteBancaire = numeroCarteBancaire.Replace(" ", "");

            int somme = 0;
            bool paire = false; 

            //additionne les chiffres du numéro de la carte bancaire selon les règles de l'algorithme de luhn
            for (int i = numeroCarteBancaire.Length - 1; i >= 0; i--)
            {
                int chiffre = int.Parse(numeroCarteBancaire[i].ToString());

                if (paire)
                {
                    chiffre = chiffre * 2;

                    if (chiffre >= 10)
                    {
                        string chiffreString = chiffre.ToString();

                        int chiffreUnite = int.Parse(chiffreString[1].ToString());
                        int chiffreDizaine = int.Parse(chiffreString[0].ToString()); 
                        somme += chiffreUnite + chiffreDizaine;
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
                paire = !paire;
            }

            bool nbValide = (somme % 10 == 0);
            if (nbValide)
            {
                return true;
            }
            else
            {
                LastError = "Numéro de carte Bancaire non valide";
                return false;
            }
        }



    }

}