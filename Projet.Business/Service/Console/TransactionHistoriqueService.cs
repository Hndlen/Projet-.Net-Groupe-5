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
            var entities = await _repo.getAll();
            var dto = entities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return dto;
        }
        public async Task<List<TransactionHistoriqueDto>> GetByDateBetween(string debut, string fin)
        {
            var entities = await _repo.GetByDateBetween(debut, fin);
            var dto = entities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return dto;
        }
        public async Task<List<TransactionHistoriqueDto>> GetByDateBetweenByNumCB(DateTime debut, DateTime fin, string numCB)
        {
            var entities = await _repo.GetByDateBetweenByNumCB(debut, fin, numCB);
            var dto = entities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return dto;
        }
        public async Task<int> Add(TransactionHistoriqueDto addDto)
        {
            var addEntity = _mapper.Map<TransactionsHistorique>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}
