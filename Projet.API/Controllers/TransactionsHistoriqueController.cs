using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;
using System.Net;

namespace Projet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsHistoriqueController : Controller
    {

        private readonly TransactionHistoriqueService transactionHistoriqueService;

        public TransactionsHistoriqueController()
        {
            this.transactionHistoriqueService = new TransactionHistoriqueService();
        }

        // GET: ProductsController
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> GetClient()
        {
            return Ok(await transactionHistoriqueService.GetAll());
        }

        [HttpGet("/{debut}/{fin}")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> GetTransactionHistoriqueBetween(string debut, string fin)
        {
            return Ok(await transactionHistoriqueService.GetByDateBetween(debut, fin));
        }
        // GET: ClientssController

        [HttpGet("/{debut}/{fin}/{numCB}")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> GetTransactionHistoriqueBetweenByNumCB(DateTime debut, DateTime fin, string numCB)
        {
            if (debut < fin)
            {
                return Ok(await transactionHistoriqueService.GetByDateBetweenByNumCB(debut, fin, numCB));
            }
            else
            {
                return BadRequest("La date de fin ne peut pas précéder la date de début");
            }
               
        }

        [HttpGet("{numCB}/{debut}/{fin}/")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> GetTransactionHistoriqueBetweenByNumCompteBancaire(string numCB, DateTime debut, DateTime fin)
        {
            if (debut < fin)
            {
                return Ok(await transactionHistoriqueService.GetbyNumCompteBetween(debut, fin, numCB));
            }
            else
            {
                return BadRequest("La date de fin ne peut pas précéder la date de début");
            }

        }

        [HttpPost("/{transaction}")]
        public async Task<ActionResult<int>> PostTransaction(TransactionHistoriqueDto transaction)
        {
            return await transactionHistoriqueService.Add(transaction);
        }
        // GET: ClientssController

    }
}
