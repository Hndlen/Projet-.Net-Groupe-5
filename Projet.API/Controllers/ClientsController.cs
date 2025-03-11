using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;

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
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClient()
        {
            return await ClientsService.GetClients();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            return await ClientsService.GetClientById(id);
        }
        // GET: ClientssController

    }
}
