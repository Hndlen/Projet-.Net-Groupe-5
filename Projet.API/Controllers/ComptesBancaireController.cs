using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;

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
        public async Task<ActionResult<IEnumerable<CompteBancaireDto>>> GetCompteBancaires()
        {
            return await CompteBancaireService.GetCompteBancaires();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CompteBancaireDto>>> GetCompteBancaireById()
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
