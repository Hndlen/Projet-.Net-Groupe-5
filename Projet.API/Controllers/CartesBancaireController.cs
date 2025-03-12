using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartesBancaireController : Controller
    {
        private readonly CarteBancaireService cartesBancaireService;

        public CartesBancaireController()
        {
            this.cartesBancaireService = new CarteBancaireService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CarteBancaireDto>>> GetCarteBancaires()
        {
            return Ok(await cartesBancaireService.GetCarteBancaires());
        }

        [HttpGet("{numero}")]
        public async Task<ActionResult<CarteBancaireDto>> GetCarteBancaireById(string numero)
        {
            var res = await cartesBancaireService.GetCarteBancaireById(numero);

            if (res == null )
            {
                return NotFound("No Products !");

            }

            return Ok(res);

        }
        // GET: CartesBancaireController

    }
}
