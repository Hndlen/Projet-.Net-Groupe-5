using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.BDD.Entities.Console;
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


        [HttpGet("{id}/{mdp}")]
        public async Task<ActionResult<CompteAdminDto>> Connexion(string id, string mdp)
        {
            if(await compteAdminService.Coonexion(id, mdp) == true)
            {
                return Ok("Connexion réussie");
            }
            else
            {
                return Unauthorized("Admin non reconnu");
            }
        }
        // GET: ClientssController

       

    }
}
