using Projet.BDD.Entities.Console;
using Projet.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projet.BDD.Repositories.Console;
using Projet.Business.Dto.Console;
using Recap.Business;
using Microsoft.EntityFrameworkCore;

namespace Projet.Business.Service.Console
{
    public class TransactionHistoriqueService
    {
        private readonly TransactionsHistoriqueRepository _repo;
        private readonly IMapper _mapper;

        public TransactionHistoriqueService()
        {
            _repo = new TransactionsHistoriqueRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<TransactionHistoriqueDto>> GetAll()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return addDto;
        }
        public async Task<List<TransactionHistoriqueDto>> GetByDateBetween(DateTime debut, DateTime fin)
        {
            var addEntities = await _repo.GetByDateBetween(debut, fin);
            var addDto = addEntities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return addDto;
        }
        public async Task<List<TransactionHistoriqueDto>> GetByDateBetweenByNumCB(DateTime debut, DateTime fin, string numCB)
        {
            var addEntities = await _repo.GetByDateBetweenByNumCB(debut, fin, numCB);
            var addDto = addEntities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return addDto;
        }
        public async Task<int> Add(TransactionHistoriqueDto addDto)
        {
            var addEntity = _mapper.Map<TransactionsHistorique>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}
