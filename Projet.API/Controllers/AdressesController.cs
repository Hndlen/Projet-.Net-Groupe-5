using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressesController : Controller
    {

        private readonly AdresseService adresseService;

        public AdressesController()
        {
            this.adresseService = new AdresseService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AdresseDto>>> GetAdresses()
        {
            return Ok(await adresseService.GetAdresses());
        }
        // GET: AdressesController

    }
}
