using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Projet.Console.ExtractionsXML
{
    public class ExtractionXML
    {
        /// <summary>
        /// Crée un fichier XML avec un élément racine et des sous-éléments.
        /// </summary>
        /// <param name="filePath">Chemin où enregistrer le fichier XML</param>
        public static void CreerXml(string filePath)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true, // Indentation pour un affichage lisible
                Encoding = System.Text.Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Personnes"); // Élément racine

                // Ajouter une première personne
                writer.WriteStartElement("Personne");
                writer.WriteElementString("Nom", "Doe");
                writer.WriteElementString("Prénom", "John");
                writer.WriteElementString("Âge", "30");
                writer.WriteEndElement();

                // Ajouter une deuxième personne
                writer.WriteStartElement("Personne");
                writer.WriteElementString("Nom", "Smith");
                writer.WriteElementString("Prénom", "Jane");
                writer.WriteElementString("Âge", "25");
                writer.WriteEndElement();

                writer.WriteEndElement(); // Fin de <Personnes>
                writer.WriteEndDocument();
            }

            //Console.WriteLine("Fichier XML créé avec succès : " + filePath);
        }
    }
}
