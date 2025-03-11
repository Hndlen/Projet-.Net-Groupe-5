using Projet.Business.Dto;
using Projet.Business.Service.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Serveur.Controllers
{
    class AnomalieController
    {
        private AnomalieService AnomalieService;

        public AnomalieController()
        {
            AnomalieService = new AnomalieService();
        }

        public async Task<int> AddAnomalie(AnomalieDto AnomalieDto)
        {
            var existingAnomalie = await AnomalieService.GetAnomaliesById(AnomalieDto.Id);
            if (existingAnomalie != null)
            {
                Console.WriteLine($"L'Anomalie' '{AnomalieDto.Id}' existe déjà !");
            }

            int result = await AnomalieService.AddAnomalie(AnomalieDto);
            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout de l'Anomalie' !");
            }

            Console.WriteLine("Anomalie ajouté avec succès !");
            return result;
        }
    }
}
