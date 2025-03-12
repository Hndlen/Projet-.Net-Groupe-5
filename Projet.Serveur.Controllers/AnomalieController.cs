using Projet.Business.Dto;
using Projet.Business.Service.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Serveur.Controllers
{
    public class AnomalieController
    {
        private AnomalieService AnomalieService;

        public AnomalieController()
        {
            AnomalieService = new AnomalieService();
        }

        public async Task<int> AddAnomalie(AnomalieDto AnomalieDto)
        {
            Console.WriteLine("entrée ajout ano");

            int result = await AnomalieService.AddAnomalie(AnomalieDto);
            Console.WriteLine("resultat operation : " + result);

            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout de l'Anomalie' !");
            }

            Console.WriteLine("Anomalie ajouté avec succès !");
            return result;
        }
    }
}
