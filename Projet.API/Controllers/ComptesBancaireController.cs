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

        private readonly CompteBancaireService compteBancaireService;

        public ComptesBancaireController()
        {
            this.compteBancaireService = new CompteBancaireService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CompteBancaireDto>>> GetCompteBancaires()
        {
            return Ok(await compteBancaireService.GetCompteBancaires());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompteBancaireDto>> GetCompteBancaireById(string id)
        {
            var res = await compteBancaireService.GetCompteBancairessById(id);
            if (res == null)
            {
                return NotFound("No Products !");

            }
            return Ok(res);

        }

        //[HttpPut("{numero},{montant}")]
        [HttpPut("{numero}")]
        public async Task<ActionResult<int>> SetMontant( string numero, [FromBody] double montant)
        {
            
            if(await compteBancaireService.MajSolde(numero, montant)>0)
            {
                return Ok("Solde modifié avec succès");
            }
            else
            {
                return NotFound("Ce numéro de compte bancaire n'existe pas");
            }

        }

    }
}
