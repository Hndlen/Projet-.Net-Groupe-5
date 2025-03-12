using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.BDD.Repositories.Console;
using Projet.BDD.Repositories.Serveur;
using Projet.Business.Dto;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service.Serveur
{
    public class EnregistrementService
    {
        private readonly EnregistrementRepository _repo;
        private readonly IMapper _mapper;

        public EnregistrementService()
        {
            _repo = new EnregistrementRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<EnregistrementDto> GetEnregistrementsById(int id)
        {
            var entities = await _repo.getById(id);
            var dto = _mapper.Map<EnregistrementDto>(entities);
            return dto;
        }
        public async Task<List<EnregistrementDto>> GetEnregistrements()
        {
            var entities = await _repo.getAll();
            var dto = entities.Select(cat => _mapper.Map<EnregistrementDto>(cat)).ToList<EnregistrementDto>();
            return dto;
        }

        public async Task<List<EnregistrementDto>> GetEnregistrementsByDate(DateTime date)
        {
            var entities = await _repo.GetbyDate(date);
            var dto = entities.Select(cat => _mapper.Map<EnregistrementDto>(cat)).ToList<EnregistrementDto>();
            return dto;
        }

        public async Task<int> AddEnregistrement(EnregistrementDto dto)
        {
            var addEntity = _mapper.Map<Enregistrement>(dto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }


    }
}
