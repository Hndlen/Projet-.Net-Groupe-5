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
            Console.WriteLine("entrée ajout enr");

            int result = await enregistrementService.AddEnregistrement(EnregistrementDto);
            Console.WriteLine("resultat operation : " + result);

            if (result == 0)
            {
                Console.WriteLine("Erreur lors de l'ajout de l'enregistrement' !");
            }

            Console.WriteLine("enregistrement ajouté avec succès !");
            return result;
        }
    }
}
