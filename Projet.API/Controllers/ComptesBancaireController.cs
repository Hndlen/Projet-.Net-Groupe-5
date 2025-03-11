using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.BDD.Entities.Console;
using Projet.Business.Dto;
using Projet.Business.Service;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComptesBancaireController : Controller
    {

        private readonly CompteBancaireService CompteBancaireService;

        public ComptesBancaireController()
        {
            this.CompteBancaireService = new CompteBancaireService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CompteBancaireDto>>> GetProducts()
        {
            return await CompteBancaireService.GetCompteBancaires();
        }

        [HttpPut("{numero},{montant}")]
        public async Task<ActionResult<int>> SetMontant(string numero, double montant)
        {
            return await CompteBancaireService.MajSolde(numero, montant);
        }
        // GET: ComptesBancaireController

    }
}
