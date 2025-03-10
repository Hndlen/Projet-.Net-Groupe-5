using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.BDD.Entities.Console;
using Projet.Business.Dto;
using Projet.Business.Service;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {

        private readonly ClientService ClientsService;

        public ClientsController()
        {
            this.ClientsService = new ClientService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetProducts()
        {
            return await ClientsService.GetClients();
        }
        // GET: ClientssController

    }
}
