using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;
using System.Net;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComptesAdminsController : Controller
    {

        private readonly CompteAdminService compteAdminService;

        public ComptesAdminsController()
        {
            this.compteAdminService = new CompteAdminService();
        }


        [HttpGet("/{id}/{fin}")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> Connexion(string id, string mdp)
        {
            return Ok(await compteAdminService.Coonexion(id, mdp));
        }
        // GET: ClientssController

       

    }
}
