using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Projet.Business.Service.Console;

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
            return await transactionHistoriqueService.GetAll();
        }

        [HttpGet("/{debut}/{fin}")]
        public async Task<ActionResult<IEnumerable<TransactionHistoriqueDto>>> GetTransactionHistoriqueBetween(DateTime debut, DateTime fin)
        {
            return await transactionHistoriqueService.GetByDateBetween(debut, fin);
        }
        // GET: ClientssController

    }
}
