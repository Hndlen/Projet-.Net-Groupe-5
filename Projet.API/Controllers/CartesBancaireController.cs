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
        private readonly CarteBancaireService CartesBancaireService;

        public CartesBancaireController()
        {
            this.CartesBancaireService = new CarteBancaireService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CarteBancaireDto>>> GetCarteBancaires()
        {
            return await CartesBancaireService.GetCarteBancaires();
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<CarteBancaireDto>> GetCarteBancaireById(string id)
        {
            return await CartesBancaireService.GetCarteBancaireById(id);
        }
        // GET: CartesBancaireController

    }
}
