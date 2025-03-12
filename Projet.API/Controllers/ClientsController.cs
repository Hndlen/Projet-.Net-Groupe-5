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

        private readonly ClientService clientsService;

        public ClientsController()
        {
            this.clientsService = new ClientService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClient()
        {
            return Ok(await clientsService.GetClients());
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            var res = clientsService.GetClientById(id);
            if (res == null)
            {
                return NotFound("No Products !");

            }
            return Ok(res);

        }
        // GET: ClientssController

    }
}
