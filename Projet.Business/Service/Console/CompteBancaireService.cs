﻿using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Repositories.Console;
using Projet.Business.Dto.Console;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service.Console
{
    public class CompteBancaireService
    {
        private readonly CompteBancaireRepository _repo;
        private readonly IMapper _mapper;

        public CompteBancaireService()
        {
            _repo = new CompteBancaireRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<CompteBancaireDto>> GetCompteBancaires()
        {
            var entities = await _repo.getAll();
            var dto = entities.Select(cat => _mapper.Map<CompteBancaireDto>(cat)).ToList();
            return dto;
        }

        public async Task<CompteBancaireDto> GetCompteBancairessById(string id)
        {
            var entities = await _repo.GetbyId(id);
            var dto = _mapper.Map<CompteBancaireDto>(entities);
            return dto;
        }

        public async Task<int> AddCompteBancaire(CompteBancaireDto addDto)
        {
            var addEntity = _mapper.Map<CompteBancaire>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }

        public async Task<int> MajSolde(string numero, double montant)
        {
            var majSaved = await _repo.MajSolde(numero, montant);
            return majSaved;
        }

    }
}
