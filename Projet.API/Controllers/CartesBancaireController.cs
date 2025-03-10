using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.BDD.Entities.Console;
using Projet.Business.Dto;
using Projet.Business.Service;

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
        public async Task<ActionResult<IEnumerable<CarteBancaireDto>>> GetProducts()
        {
            return await CartesBancaireService.GetCarteBancaires();
        }
        // GET: CartesBancaireController

    }
}
