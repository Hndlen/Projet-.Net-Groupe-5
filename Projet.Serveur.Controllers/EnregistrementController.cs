using Projet.Business.Dto;
using Projet.Business.Service.Serveur;

namespace Projet.Serveur.Controllers
{
    public class EnregistrementController
    {
        private EnregistrementService enregistrementService;

        public EnregistrementController()
        {
            enregistrementService = new EnregistrementService();
        }

        public async Task<int> AddEnregistrement(EnregistrementDto EnregistrementDto)
        {
            var existingEnregistrement = await enregistrementService.GetEnregistrementsById(EnregistrementDto.Id);
            if (existingEnregistrement != null)
            {
                Console.WriteLine($"L'enregistrement' '{EnregistrementDto.Id}' existe déjà !");
            }

            int result = await enregistrementService.AddEnregistrement(EnregistrementDto);
            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout de l'enregistrement' !");
            }

            Console.WriteLine("enregistrement ajouté avec succès !");
            return result;
        }
    }
}
