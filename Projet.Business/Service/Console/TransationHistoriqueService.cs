﻿using Projet.BDD.Entities.Console;
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
    class TransationHistoriqueService
    {
        private readonly TransactionsHistoriqueRepository _repo;
        private readonly IMapper _mapper;

        public TransationHistoriqueService()
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
        public async Task<List<TransactionHistoriqueDto?>> GetByDateBetween(DateTime debut, DateTime fin)
        {
            var addEntities = await _repo.GetByDateBetween(debut, fin);
            var addDto = addEntities.Select(cat => _mapper.Map<TransactionHistoriqueDto>(cat)).ToList();
            return addDto;
        }

    }
}
