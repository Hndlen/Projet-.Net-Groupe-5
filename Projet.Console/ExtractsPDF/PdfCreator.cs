using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

public class PdfCreator
{
    /// <summary>
    /// Crée un fichier PDF avec du texte simple.
    /// </summary>
    /// <param name="filePath2">Chemin du fichier PDF</param>
    /// <param name="contenu">Texte à ajouter dans le PDF</param>
    public static void CreerPdf(string filePath2, string contenu)
    {
        using (PdfWriter writer = new PdfWriter(filePath2))
        using (PdfDocument pdf = new PdfDocument(writer))
        using (Document document = new Document(pdf))
        {
            document.Add(new Paragraph(contenu));
        }

        Console.WriteLine("PDF créé avec succès : " + filePath2);
    }
}