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
            var addEntities = await _repo.getById(id);
            var addDto = _mapper.Map<EnregistrementDto>(addEntities);
            return addDto;
        }
        public async Task<List<EnregistrementDto>> GetEnregistrements()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<EnregistrementDto>(cat)).ToList<EnregistrementDto>();
            return addDto;
        }

        public async Task<List<EnregistrementDto>> GetEnregistrementsByDate(DateTime date)
        {
            var addEntities = await _repo.GetbyDate(date);
            var addDto = addEntities.Select(cat => _mapper.Map<EnregistrementDto>(cat)).ToList<EnregistrementDto>();
            return addDto;
        }

        public async Task<int> AddEnregistrement(EnregistrementDto addDto)
        {
            var addEntity = _mapper.Map<Enregistrement>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }


    }
}
